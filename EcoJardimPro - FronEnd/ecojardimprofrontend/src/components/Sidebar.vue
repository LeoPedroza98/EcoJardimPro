<template>
    <v-navigation-drawer v-model="abrirSidebar" v-if="isLogin" app id="nav-border" width="307">
        <v-list-item>
            <v-list-item-avatar>

            </v-list-item-avatar>
            <v-list-item-content>
                <v-list-item-title>EcoJardimPro</v-list-item-title>
            </v-list-item-content>
        </v-list-item>
        <v-divider></v-divider>
        <v-list nav>
            <v-list-item-group>
                <v-list-item v-for="item in items" :key="item.name" v-show="verificaAcesso(item.roles, item.permissions)"
                    :to="item.path" :class="{
                        'success white--text': isActive(item),
                        'text--disabled': desabilitaModulosComplementares(item.roles, item.permissions)
                    }" id="items-sidebar" :inactive="desabilitaModulosComplementares(item.roles, item.permissions)">
                    <v-list-item-icon>
                        <v-icon>{{ item.icon }}</v-icon>
                    </v-list-item-icon>
                    <v-tooltip right>
                        <template v-slot:activator="{ on, attrs }">
                            <v-list-item-content v-bind="attrs" v-on="on">
                                <v-list-item-title class="custom-font-size">{{ item.label }}</v-list-item-title>
                            </v-list-item-content>
                        </template>
                    </v-tooltip>
                </v-list-item>
            </v-list-item-group>
        </v-list>
        <template v-slot:append>
            <div class="pa-2">
                <v-btn color="error" block outlined @click="sair" title="Sair do Sistema" class="sair-btn">
                    <v-icon>mdi-logout</v-icon>
                    Sair do Sistema
                </v-btn>
            </div>
        </template>
    </v-navigation-drawer>
</template>
  
<script lang="ts">
import Vue from 'vue';
import { AlertaPerguntaSimOuNaoBooleano } from "../helpers/MensagemHelper";
import NavigationHelper from "../helpers/NavigationHelper";
import { decode, getToken, removeToken } from '@/config/Token';
import AuthUserModel from '@/models/Authentication/AuthUser';
import sidebarItems from "../router/sidebar";


export default Vue.extend({
    name: "sidebar",
    props: {
        value: {
            type: Boolean,
        },
    },
    watch: {
        value() {
            this.abrirSidebar = this.value;
        },
        abrirSidebar(val) {
            this.$emit("input", this.abrirSidebar);
        },
        "$route.name": {
            handler: function (name) {
                this.isLogin = name != "login" && name != "recuperarSenha" && name != "confirmaEmail" ? true : false;
                if (name == "home") {
                    this.abrirSidebar = true;
                }
            },
        },
    },
    data() {
        return {
            abrirSidebar: false,
            itemMenuSelecionado: 1,
            itensMenu: [
                { text: "Perfil do Usuário", icon: "mdi-account" },
                { text: "Sair", icon: "mdi-logout" },
            ],

            isLogin: false,
            get items() {
                return sidebarItems;
            },
        };
    },
    methods: {
        verificaAcesso(roles: string[], permissions: string[]) {
            //TODO: Implementar a validação das permissões
            var sessaoUsuario: AuthUserModel = new AuthUserModel();
            sessaoUsuario = decode(getToken())
            return roles.includes(sessaoUsuario.role);
        },

        desabilitaModulosComplementares(roles: string[], permissions: string[]) {
            var sessaoUsuario: AuthUserModel = new AuthUserModel();
            sessaoUsuario = decode(getToken());

            if (roles.includes(sessaoUsuario.role)) {
                if (permissions.every(item => sessaoUsuario.permissions.includes(item))) {
                    return false;
                }

                return true;
            }

            return true;
        },

        selecionarRota(nomeRota: string) {
            NavigationHelper.navigate(nomeRota);
        },

        async sair() {
            if (await AlertaPerguntaSimOuNaoBooleano("Deseja sair do sistema?")) {
                removeToken();
                this.$vuetify.theme.dark = false;
                NavigationHelper.navigate("login");
                this.$root.$emit('limpar-informacoes-usuario');
            }
        },

        isActive(route: any): boolean {
            if (this.$route.name === route.name) {
                return true;
            }

            if (route.relatedRoutes) {
                return route.relatedRoutes.some(
                    (name: string) => name === this.$route.name
                );
            }

            return false;
        },
    },
});
</script>
  
<style scoped>
a {
    text-decoration: none;
}

.custom-font-size {
    font-size: 1.105rem;
}

.sair-btn:hover {
    background-color: rgba(255, 201, 200, 0.8);
    color: #ffffff;
    box-shadow: 1.4rem rgba(54, 53, 53, 0.1);
    transform: scale(1.03);
    transition: transform 0.3s ease;
}

#nav-border {
    border-right: 2px solid #2dcb73;
    box-shadow: 4px 8px 4px -3px rgba(0, 0, 0, 0.25);
}

#items-sidebar:hover {
    background-color: rgba(45, 203, 115, 0.2);
    font-weight: 900;
}
</style>