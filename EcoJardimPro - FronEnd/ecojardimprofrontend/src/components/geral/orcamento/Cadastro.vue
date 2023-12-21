<template>
    <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition" persistent>
        <v-card style="border-radius: 0px !important; background: var(--v-cadastroBackground-base)">
            <v-card-title class="pa-0 dialogHeader">
                <v-toolbar src="@/assets/images/ecojardimproheader.jpeg" flat dark height="65px">
                    <div style="display: flex; align-items: center; width: 100%; height: 100%">
                        <v-btn icon @click="Close()" class="mr-4">
                            <v-icon color="red">mdi-close</v-icon>
                        </v-btn>
                        <v-toolbar-title color="black">{{ item.id > 0 ? "Editar" : "Criar" }} Orçamento </v-toolbar-title>
                        <v-spacer />
                        <v-toolbar-items>
                            <v-btn color="#4CAF50" background-color="#4CAF50" text @click="Salvar()">
                                Salvar
                            </v-btn>
                        </v-toolbar-items>
                    </div>
                    <template v-slot:extension>
                        <v-tabs v-model="tabActive" color="black">
                            <v-tab>Orçamento</v-tab>
                            <v-tab>Serviços</v-tab>
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
                                        <v-card-title>Orçamento</v-card-title>
                                        <v-card-text class="mt-2">
                                            <v-row dense>
                                                <v-col cols="12" sm="12" md="6" lg="6">
                                                    <v-select color="#4CAF50" v-model="item.projetoId" label="Projetos" :rules="fieldRules"
                                                        item-value="id" item-text="nome" :items="projetos" outlined dense />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="6" lg="6">
                                                    <v-text-field color="#4CAF50" v-model="item.nome" label="Nome"
                                                        :rules="fieldRules" :counter="60" dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="6" lg="6">
                                                    <v-text-field color="#4CAF50" v-model="item.descricao" label="Descrição"
                                                        :rules="fieldRules" :counter="60" dense outlined />
                                                </v-col>
                                                <v-col cols="12" sm="12" md="6" lg="6">
                                                    <v-text-field color="#4CAF50" v-model="item.dataCriacao" label="Data de Criação"
                                                        :rules="fieldRules" :counter="60" dense outlined />
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
import { Orcamento } from '@/core/models/geral/Orcamento';
import { OrcamentoService, ProjetoService } from '@/core/services/geral';
import { AlertaSimples, AlertaSimplesAsync, AlertaSimplesErro, AlertaSimplesResponse } from '@/components/shared/AlertService';
import { Projeto, Servico } from '@/core/models/geral';

@Component
export default class CadastroOrcamento extends PageBase {
    @Prop() private item!: Orcamento;
    @Prop() private value!: string;

    tabActive: any = {};

    itemOriginal!: Orcamento;
    dialog: boolean = false;
    service: OrcamentoService = new OrcamentoService();
    valid: boolean = true;
    fieldRules: any[] = [(v: any) => !!v || "Campo obrigatório"];
    $refs!: {
        form: HTMLFormElement,
        file: HTMLFormElement
    }

    projetoId: number = 0;
    projetoService = new ProjetoService();
    isProjetoLoading: boolean = false;
    onSearchProjetos: any = null;
    projetos: Projeto[] = [];

    dialogServico = false;
    editaServico = false;
    servico : Servico = new Servico();

    headerServicos: any[] = [
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

    @Watch('onSearchProjetos')
    SearchProjetos(val: string) {
        if (this.projetoId) return;
        if (this.isProjetoLoading) return;
        if (!val) return;
        this.isProjetoLoading = true
        this.projetoService.AutoComplete(val)
        .then(
            res => {
                this.projetos = res.data;
            },
            err => this.$swal('Aviso', err.response.data, 'error')
        ).finally(() => {
            this.isProjetoLoading = false;
        })
    }


    mounted() {
        this.projetoService.ListarTudo().then(
            res => {
                this.projetos = res.data.items;
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
                    AlertaSimplesResponse("Aviso", res);
                    this.$emit("salvou");
                    this.Close();
                },
                err => {
                    AlertaSimplesErro("Aviso", err);
                }
            )
        }
    }

    AbrirDialogServico(servico?: Servico){
        if(servico){
            this.servico = servico;
            this.editaServico = true;
        }
        else{
            this.servico = new Servico();
            this.editaServico = false;
        }
        this.dialogServico = true;
    }

    ExcluirServico(servico?:Servico){
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