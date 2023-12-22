<template>
    <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition" persistent>
        <v-card style="border-radius: 0px !important; background: var(--v-cadastroBackground-base)">
            <v-card-title class="pa-0 dialogHeader">
                <v-toolbar src="@/assets/images/ecojardimproheader.jpeg" flat dark height="65px">
                    <div style="display: flex; align-items: center; width: 100%; height: 100%">
                        <v-btn icon @click="Close()" class="mr-4">
                            <v-icon color="red">mdi-close</v-icon>
                        </v-btn>
                        <v-toolbar-title color="black">{{ item.id > 0 ? "Editar" : "Criar" }} Projeto </v-toolbar-title>
                        <v-spacer />
                        <v-toolbar-items>
                            <v-btn class="btn btn-primary" @click="Salvar()"> <v-icon>mdi-plus</v-icon> Salvar
                            </v-btn>
                        </v-toolbar-items>
                    </div>
                    <template v-slot:extension>
                        <v-tabs v-model="tabActive" color="black">
                            <v-tab>Projeto</v-tab>
                        </v-tabs>
                    </template>
                </v-toolbar>
            </v-card-title>
            <v-card-text class="mt-5" :class="$vuetify.breakpoint.smAndDown ? 'px-2' : 'px-4'">
                <v-form ref="form" v-model="valid" lazy-validation>
                    <v-tabs-items v-model="tabActive">
                        <v-tab-item>
                            <v-row dense>
                                <v-col cols="12" sm="12" md="12">
                                    <v-card flat>
                                        <v-card-title>Projeto</v-card-title>
                                        <v-card-text class="mt-2">
                                            <v-row dense>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-select color="#4CAF50" v-model="item.clienteId" label="Clientes" :rules="fieldRules"
                                                        item-value="id" item-text="nome" :items="clientes" outlined dense />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.nome" label="Nome" :rules="fieldRules"
                                                        :counter="30" dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.descricao" label="Descrição"
                                                        :rules="fieldRules" :counter="80" dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field type="date" color="#4CAF50" v-model="item.prazoInicial" label="Data Inicial"
                                                        :rules="fieldRules" :counter="60" dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field type="date" color="#4CAF50" v-model="item.prazoFinal" label="Data Final Estimativa"
                                                        dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.valor" label="Valor estimado" dense
                                                        outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-select color="#4CAF50" v-model="item.statusId" label="Status" :rules="fieldRules"
                                                        item-value="id" item-text="nome" :items="status" outlined dense />
                                                </v-col>
                                            </v-row>
                                        </v-card-text>
                                    </v-card>
                                </v-col>
                            </v-row>
                        </v-tab-item>
                    </v-tabs-items>
                </v-form>
            </v-card-text>
        </v-card>
    </v-dialog>
</template>
<script lang="ts">
import { Vue, Component, Watch, Prop } from 'vue-property-decorator'
import jiff from 'jiff';
import { PageBase } from '@/core/models/shared';
import { Cliente, Projeto, Status } from '@/core/models/geral';
import { ClienteService, ProjetoService, StatusService } from '@/core/services/geral';
import { AlertaSimples, AlertaSimplesAsync, AlertaSimplesErro, AlertaSimplesResponse } from '@/components/shared/AlertService';


@Component
export default class CadastroProjeto extends PageBase {
    @Prop() private item!: Projeto;
    @Prop() private value!: string;

    tabActive: any = {};

    itemOriginal!: Projeto;
    dialog: boolean = false;
    service: ProjetoService = new ProjetoService();
    valid: boolean = true;
    fieldRules: any[] = [(v: any) => !!v || "Campo obrigatório"];
    $refs!: {
        form: HTMLFormElement,
        file: HTMLFormElement
    }

    statusId: number = 0;
    statusService = new StatusService();
    isStatusLoading: boolean = false;
    onSearchStatus: any = null;
    status: Status[] = [];

    clienteId: number = 0;
    clienteService = new ClienteService();
    isClienteLoading: boolean = false;
    onSearchClientes: any = null;
    clientes:Cliente[] = [];

    @Watch('value')
    Value() {
        this.dialog = this.value ? true : false;
    }

    @Watch("dialog")
    Dialog() {
        if (!this.dialog) {
            this.$emit("fechou");
        }
    }

    @Watch('item')
    ItemWatch() {
        if (this.item.id > 0) {
            this.itemOriginal = jiff.clone(this.item);
        }
        if (this.$refs.form) {
            this.$refs.form.resetValidation();
        }
    }

    @Watch('onSearchStatus')
    SearchStatus(val: string) {
        if (this.item.statusId) return;
        if (this.isStatusLoading) return;
        if (!val) return;
        this.isStatusLoading = true
        this.statusService.AutoComplete(val)
            .then(
                res => {
                    this.status = res.data;
                },
                err => this.$swal('Aviso', err.response.data, 'error')
            ).finally(() => {
                this.isStatusLoading = false;
            })
    }

    @Watch('onSearchClientes')
    SearchClientes(val: string) {
        if (this.clienteId) return;
        if (this.isClienteLoading) return;
        if (!val) return;
        this.isClienteLoading = true
        this.clienteService.AutoComplete(val)
            .then(
                res => {
                    this.clientes = res.data;
                },
                err => this.$swal('Aviso', err.response.data, 'error')
            ).finally(() => {
                this.isStatusLoading = false;
            })
    }

    beforeUpdate() {
        if (!this.dialog) {
            this.$emit('fechou');
        }
    }

    mounted() {
        this.statusService.ListarTudo().then(
            res => {
                this.status = res.data.items;
            },
            err => {
                this.$swal('Aviso', err.message, 'error')
            }
        ),
        this.clienteService.ListarTudo().then(
            res => {
                this.clientes = res.data.items;
            },
            err => {
                this.$swal('Aviso', err.message, 'error')
            }
        )

    }



    Salvar() {
        if (this.$refs.form.validate()) {
            let patchModel = jiff.diff(this.itemOriginal, this.item, false);

            (this.item.id > 0 ? this.service.Salvar(patchModel, this.item.id) : this.service.Salvar(this.item)).then(
                res => {
                    this.$swal("Aviso", "Operação realizada com sucesso!", res.status == 201 || res.status == 200 ? "success" : "warning");
                    this.$emit("salvou");
                    this.Close();
                },
                err => {
                    AlertaSimplesErro("Aviso", err);
                }
            )
        }
    }

    Close() {
        this.dialog = false;
    }
}
</script>
<style lang="scss">
.v-card {
    border-radius: 5px !important;
}

.v-toolbar__title {
    color: black;
}
</style>