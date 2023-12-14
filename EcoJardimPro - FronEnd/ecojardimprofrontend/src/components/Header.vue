<template>
    <v-app-bar color="black" dense app v-if="visualizar" elevate-on-scroll>
        <v-app-bar-nav-icon @click.stop="$emit('input', !abrirSidebar)"></v-app-bar-nav-icon>
        <v-spacer></v-spacer>
        <v-menu bottom min-width="200px" rounded offset-y>
            <template v-slot:activator="{ on }">
                <v-btn icon x-large v-on="on" title="Opções do Usuário">
                    <v-avatar size="42" class="white--text text-h5 success darken-2">
                        <span>{{ formatarIniciaisNomeSobrenome(user.name, user.sobrenome) }}</span>
                    </v-avatar>
                </v-btn>
            </template>
            <v-card>
                <v-list dense class="justify-center">
                    <div class="mx-auto text-center">
                        <span style="font-size: 12px" class="text-caption">Logado como</span>
                        <h5 v-if="user.sobrenome && user.name && user.role !== 'Admin'">{{ user.name }} {{ user.sobrenome }}
                        </h5>
                        <h5 v-else></h5>

                        <span style="font-size: 12px" class="text-caption">{{ user.role == 'Admin' ? 'Administrador Master' :
                            user.role }}</span>
                        <v-divider class="my-3"></v-divider>
                    
                        <v-list-item>
                            <v-list-item-icon><v-icon>mdi-account-circle-outline</v-icon></v-list-item-icon>
                            <v-list-item-title>Seu Perfil</v-list-item-title>
                        </v-list-item>
                        <v-divider class="my-1"></v-divider>
                        <v-list-item @click="sair()">
                            <v-list-item-icon><v-icon>mdi-logout</v-icon></v-list-item-icon>
                            <v-list-item-title>Sair</v-list-item-title>
                        </v-list-item>
                    </div>
                </v-list>
            </v-card>
        </v-menu>
    </v-app-bar>
</template>
  
  
<script lang="ts">
import Vue from "vue";
import NavigationHelper from "../helpers/NavigationHelper";
import { getModoNoturno, removeToken, setModoNoturno, decode, getToken } from "../config/Token";
import { AlertaPerguntaSimOuNaoBooleano } from "../helpers/MensagemHelper";
import { UsuarioService } from "../services/UsuarioService";
export default Vue.extend({
    name: "header",
    props: {
        value: {
            type: Boolean,
        },
    },
    watch: {
        value() {
            this.abrirSidebar = this.value;
        },

        user() {
            this.modoNoturno = getModoNoturno();
        },

        "$route.name": {
            handler: function (name) {
                this.visualizar = name != "login" ? true : false;
            },
        },
    },
    data() {
        return {
            abrirSidebar: false,
            visualizar: false,
            user: null,
            modoNoturno: getModoNoturno(),
        };
    },

    mounted() {
        this.atualizarInformacoesUsuario();
        this.$root.$on('atualizar-usuario', this.atualizarInformacoesUsuario);
    },

    methods: {
        atualizarInformacoesUsuario() {
            const token = getToken();
            if (token) {
                this.user = decode(token);
            }
        },

        async sair() {
            if (await AlertaPerguntaSimOuNaoBooleano("Deseja sair do sistema?")) {
                removeToken();
                this.$vuetify.theme.dark = false;
                NavigationHelper.navigate("login");
            }
        },
        formatarIniciaisNomeSobrenome(nome: string, sobrenome: string) {
            if (nome && sobrenome) {
                const iniciais = nome.charAt(0).toUpperCase() + sobrenome.charAt(0).toUpperCase();
                return iniciais;
            } else if (nome) {
                return nome.charAt(0).toUpperCase();
            }
            return 'H';
        },
    },
});
</script>
  
<style scoped>
#title-system {
    /* color: #2dcb73; */
    color: white;
    font-family: "Open Sans", Arial, sans-serif;
    font-weight: 700;
    font-size: 14px;
    padding-left: 1rem;
}
</style>
  