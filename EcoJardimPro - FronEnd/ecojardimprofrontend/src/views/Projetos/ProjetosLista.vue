<template>
    <v-card>
        <v-card-title>
            Projetos
            <v-spacer></v-spacer>
            <!-- <v-btn v-if="nomeRota == 'clientes'" :to="{ name: 'clientesform' }">
                <v-icon left>mdi mdi-account-plus</v-icon>
                Novo Cliente
            </v-btn> -->
        </v-card-title>
        <v-card-subtitle>{{
            'Listagem de Projetos'
        }}</v-card-subtitle>
        <v-card-text>
            <v-card>
                <v-card-title>
                    <v-row>
                    </v-row>
                    <v-row>
                    </v-row>
                </v-card-title>
                <v-card-text>
                    <v-data-table :headers="colunas" no-data-text="Nenhum projeto encontrado!"
                        :loading="carregando ? 'success' : null" :header-props="headerProps"
                        loading-text="Carregando os itens desta tabela! Aguarde..." hide-default-footer
                        :items-per-page="itens" :items="pacientes" :page.sync="paginaAtual">
                        <template v-slot:item.actions="{ item }">
                            <!-- <v-btn class="mx-2" x-small fab color="success" v-if="nomeRota == 'clientes'" :to="{
                                name: 'pacientesFormUpdate',
                                params: { pacienteId: item.id },
                            }" title="Editar Cliente" :disabled="item.ativo === false">
                                <v-icon small>mdi-pencil</v-icon>
                            </v-btn> -->
                            <!-- <v-btn class="mx-2" x-small fab color="primary" v-if="nomeRota == 'pacientes'" :to="{
                                name: 'pacientesFormView',
                                params: { pacienteId: item.id },
                            }" title="Visualizar Paciente" :disabled="item.ativo === false">
                                <v-icon small>mdi-magnify</v-icon>
                            </v-btn> -->
                        </template>
                    </v-data-table>
                    <v-pagination
                    color="success"
                    @input="listar"
                    v-model="paginaAtual"
                    :length="totalPaginas"
                    :total-visible="5"
                ></v-pagination>
                </v-card-text>
            </v-card>
        </v-card-text>
    </v-card>
</template>
<script lang="ts">
import Vue from 'vue'

export default Vue.extend({
    computed: {
        nomeRota() {
            return this.$route.name;
        },
        labelFiltro() {
            const itemSelecionado = this.opcoesFiltro.find(item => item.key === this.tipoFiltro);

            if (itemSelecionado) {
                return `Digite um(a) ${itemSelecionado.name} para pesquisar...`;
            }

            return 'Digite o que deseja pesquisar...';
        },
        tipoFiltroComputado() {
            return this.opcoesFiltro.find((x) => x.key == this.tipoFiltro)
                ?.type;
        },
    },
    data() {
        return {
            carregando: false,
            // service: new PacientesService(),
            // clientes: [],
            valorFiltro: '',
            totalPaginas: 0,
            paginaAtual: 1,
            itens: 0,
            headerProps: {
                sortByText: 'Ordenar por',
            },
            quantidadeItens: [
                { value: 5, text: 5 },
                { value: 10, text: 10 },
                { value: 15, text: 15 },
            ],
            colunas: [
                {
                    text: 'ID',
                    align: 'start',
                    value: 'id',
                    filterable: true,
                    sortable: true,
                },
                {
                    text: 'Nome Projeto',
                    value: 'nomeCompleto',
                    filterable: true,
                    sortable: true,
                },
                {
                    text: 'Ações',
                    value: 'actions',
                },
            ],
            situacaoPaciente: false,
            carregandoAtendimento: false
        };
    },
})
</script>