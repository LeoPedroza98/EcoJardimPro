<template>
  <master-page titulo="Serviços" icone="mdi-account-wrench">
    <v-card-title class="listHeader">
      <v-row style="display: flex; align-items: center">
        <v-col cols="12" sm="12" md="5" style="display: flex; align-items: center;">
          <text-search :search.sync="search" @mudou="Atualizar()" />
        </v-col>
        <v-spacer />
        <v-col cols="12" sm="12" md="7"
          style="display: flex; flex-wrap: wrap; row-gap: 15px; align-items: center; column-gap:10px"
          :style="!$vuetify.breakpoint.mobile ? 'justify-content: flex-end' : 'justify-content: space-evenly'">
          <v-btn class="btn" @click="Atualizar()"> <v-icon>mdi-update</v-icon> Atualizar </v-btn>
          <v-btn class="btn btn-primary" @click="AbrirDialogCadastro()"> <v-icon>mdi-plus</v-icon> Adicionar
          </v-btn>
        </v-col>
      </v-row>
    </v-card-title>
    <v-card-text class="px-0">
      <v-data-table id="tabela" class="table" :headers="headerList" :items="lista" :options.sync="options"
        :page.sync="page" @page-count="pageCount = $event" :server-items-length="total" :loading="loading"
        hide-default-footer>
        <template v-slot:[`item.actions`]="{ item }">
          <div style="display: flex; justify-content: center; align-items: center">
            <v-icon @click="AbrirDialogCadastro(item)">mdi-pencil</v-icon>
            <v-icon @click="ExcluirRegistro(item)">mdi-delete</v-icon>
          </div>
        </template>
      </v-data-table>
      <div class="mt-4 mx-3">
        <v-row style="display: flex; justify-content: flex-end; align-items: center;" dense>
          <v-col cols="12" sm="2" md="1">
            <v-select flat label="Itens por página" v-model="options.itemsPerPage" :items="itemsPage" item-value="value"
              item-text="text" hide-details dense />
          </v-col>
          <v-col cols="12" sm="auto" md="auto">
            <v-pagination v-model="page" :length="pageCount" />
          </v-col>
        </v-row>
      </div>
    </v-card-text>
    <v-bottom-sheet v-model="sheet">
      <v-sheet>
        <v-card style="background: var(--v-cadastroBackground-base)">
          <v-card-title>
            <v-icon color="primary" style="font-size: 24px;">mdi-filter</v-icon>
            <div class="pl-3">
              <span style="font-size: 20px">Filtros</span>
            </div>
          </v-card-title>
          <v-card-text class="ma-2">
            <v-row>
              <v-col cols="12" sm="4" md="4">
                <v-text-field label="Nome" dense />
              </v-col>
            </v-row>
          </v-card-text>
          <v-card-actions class="mx-4">
            <v-spacer />
            <v-btn text color="primary" @click="Atualizar(true)">Filtrar</v-btn>
          </v-card-actions>
        </v-card>
      </v-sheet>
    </v-bottom-sheet>
    <cadastro-servico v-model="dialogCadastro" :item="item" @fechou="dialogCadastro = false" @salvou="Atualizar()" />
  </master-page>
</template>
<script lang="ts">

import { Vue, Component, Watch } from 'vue-property-decorator'
import { ServicoService, UsuarioService } from '../../../core/services/geral'
import { PageBase } from '@/core/models/shared';
import { AlertaSimplesErro, AlertExcludeQuestion } from '@/components/shared/AlertService';
import { Servico } from '@/core/models/geral';

@Component
export default class ListaServicos extends PageBase {

  lista: any[] = [];
  item: Servico = new Servico();
  service: ServicoService = new ServicoService();
  search: string = '';
  loading: boolean = false;
  sheet: boolean = false;
  listaSheet: boolean = false;
  dialogCadastro: boolean = false;
  total: number = 0;
  options: any = {
    itemsPerPage: 15
  }
  page: number = 1;
  pageCount: number = 1;
  itemsPage: any[] = [
    { text: "Todos", value: -1 },
    { text: "5", value: 5 },
    { text: "10", value: 10 },
    { text: "15", value: 15 },
  ];
  header: any[] = [
    { text: '', value: 'actions', sortable: false, class: 'action', use: true },
    { text: 'Nome do Serviço', value: 'nome', use: true },
    { text: 'Projeto', value: 'orcamento.projeto.nome', use: true },
    { text: 'Orçamento', value: 'orcamento.descricao', use: true },
    { text: 'Descrição', value: 'descricao', use: true },
    { text: 'Valor', value: 'valor', use: true },
    { text: 'Status', value: 'status.nome', use: true },
  ];
  $vuetify: any;

  get headerList() {
    return this.header.filter(x => x.use == true);
  }

  @Watch('options', { deep: true })
  Atualizar(isFiltro: boolean = false) {

    if (isFiltro == true) {
      this.options.page = 1;
      this.sheet = false;
    }

    const { page, itemsPerPage, sortBy, sortDesc, search, columns } = this.options;
    this.loading = true;

    this.service.Listar(page, itemsPerPage, sortBy, sortDesc, this.search, this.header,undefined, 'Status,Orcamento.Projeto').then(
      res => {
        this.lista = res.data.items;
        this.total = res.data.count;
      },
      err => {
        AlertaSimplesErro("Aviso", err);
      }
    )
      .finally(() => (this.loading = false));
  }

  AbrirDialogCadastro(item?: Servico) {
    if(item){
        this.service.ObterPorId(item.id,"Orcamento,Status").then(
            res => {
                this.item = new Servico(res.data);
            },
            err => {
                AlertaSimplesErro("Aviso", err);
            }
        )
    }
    else{
        this.item = new Servico();
    }

    this.dialogCadastro = true;
  }

  ExcluirRegistro(item: any) {

    const service = this.service;

    const excluir = function () {
      return new Promise(async function (resolve, reject) {
        await service.Excluir(item.id).then(
          res => {
            if (res.status == 200) {
              return res.data;
            }
          },
          err => {
            AlertaSimplesErro("Aviso", err);
          }
        )
      });
    }

    AlertExcludeQuestion(excluir).finally(() => {
      this.Atualizar();
    });
  }

}
</script>
<style lang="scss">
.action {
  width: 75px;
}

.foto {
  width: 120px;
}

.v-pagination {
  box-shadow: 1px black !important;
}

.page-item {
  background: red !important;
}</style>
