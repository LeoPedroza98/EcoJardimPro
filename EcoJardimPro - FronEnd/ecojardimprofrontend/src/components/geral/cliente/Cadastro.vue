<template>
    <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition" persistent>
        <v-card style="border-radius: 0px !important; background: var(--v-cadastroBackground-base)">
            <v-card-title class="pa-0 dialogHeader">
                <v-toolbar src="@/assets/images/ecojardimproheader.jpeg" flat dark height="65px">
                    <div style="display: flex; align-items: center; width: 100%; height: 100%">
                        <v-btn icon @click="Close()" class="mr-4">
                            <v-icon color="red">mdi-close</v-icon>
                        </v-btn>
                        <v-toolbar-title color="black">{{ item.id > 0 ? "Editar" : "Criar" }} Cliente </v-toolbar-title>
                        <v-spacer />
                        <v-toolbar-items>
                            <v-btn class="btn btn-primary" @click="Salvar()"> <v-icon>mdi-plus</v-icon> Salvar
                            </v-btn>
                        </v-toolbar-items>
                    </div>
                    <template v-slot:extension>
                        <v-tabs v-model="tabActive" color="black">
                            <v-tab>Cliente</v-tab>
                            
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
                                        <v-spacer></v-spacer>
                                        <v-card-title>Cliente</v-card-title>
                                        <v-card-text class="mt-2">
                                            <v-row dense>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.nome" label="Nome" :rules="fieldRules"
                                                        :counter="20" dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.sobrenome" label="Sobrenome"
                                                        :rules="fieldRules" :counter="30" dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.documento" label="Documento"
                                                        :rules="fieldRules" :counter="30" dense outlined />
                                                </v-col>
                                            </v-row>
                                        </v-card-text>
                                    </v-card>
                                </v-col>
                            </v-row>
                            <v-row dense>
                                <v-col cols="12" sm="12" md="12">
                                    <v-card flat>
                                        <v-card-title>Endereço</v-card-title>
                                        <v-card-text class="mt-2">
                                            <v-row dense>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.endereco.cep" label="CEP" :counter="20"
                                                        dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.endereco.logradouro" label="Logradouro"
                                                        dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.endereco.numero" label="Numero" dense
                                                        outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.endereco.complemento" label="Complemento"
                                                        dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.endereco.bairro" label="Bairro" dense
                                                        outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="4" lg="4">
                                                    <v-text-field color="#4CAF50" v-model="item.endereco.municipio" label="Municipio" dense
                                                        outlined />
                                                </v-col>
                                            </v-row>
                                        </v-card-text>
                                    </v-card>
                                </v-col>
                            </v-row>
                            <v-row dense>
                                <v-col cols="12" sm="12" md="12">
                                    <v-card flat>
                                        <v-card-title>Contato</v-card-title>
                                        <v-card-text class="mt-2">
                                            <v-row dense>
                                                <v-col cols="12" sm="12" md="6" lg="6">
                                                    <v-text-field color="#4CAF50" v-model="item.contato.nome" label="Nome do Contato" :counter="20"
                                                        dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="6" lg="6">
                                                    <v-text-field color="#4CAF50" v-model="item.contato.email" label="Email"
                                                        dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="6" lg="6">
                                                    <v-text-field color="#4CAF50" v-model="item.contato.celular" label="Celular" :counter="11"
                                                        dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="6" lg="6">
                                                    <v-text-field color="#4CAF50" v-model="item.contato.telefone" label="Telefone Fixo"
                                                        dense outlined />
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
import { Cliente } from '@/core/models/geral';
import { ClienteService } from '@/core/services/geral';
import { AlertaSimples, AlertaSimplesAsync, AlertaSimplesErro, AlertaSimplesResponse } from '@/components/shared/AlertService';

@Component
export default class CadastroCliente extends PageBase {
    @Prop() private item!: Cliente;
    @Prop() private value!: string;

    tabActive: any = {};

    itemOriginal!: Cliente;
    dialog: boolean = false;
    service: ClienteService = new ClienteService();
    valid: boolean = true;
    fieldRules: any[] = [(v: any) => !!v || "Campo obrigatório"];
    $refs!: {
        form: HTMLFormElement,
        file: HTMLFormElement
    }

    headerProjeto: any[] = [
        { text: '', value: 'actions', sortable: false },
    ]

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


    beforeUpdate() {
        if (!this.dialog) {
            this.$emit('fechou');
        }
    }

    mounted() {
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
<style lang="scss">.v-card {
    border-radius: 5px !important;
}

.v-toolbar__title {
    color: black;
}</style>