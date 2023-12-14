<template>
    <v-navigation-drawer v-model="abrirSidebar" v-if="isLogin" app id="nav-border">
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
                <v-list-item v-for="item in items" :key="item.name"
                    :to="item.path" :class="{
                        'black white--text': isActive(item),
                    }" id="items-sidebar">
                    <v-list-item-icon>
                        <v-icon>{{ item.icon }}</v-icon>
                    </v-list-item-icon>
                    <v-tooltip right>
                        <template v-slot:activator="{ on, attrs }">
                            <v-list-item-content v-bind="attrs" v-on="on">
                                <v-list-item-title>{{ item.label }}</v-list-item-title>
                            </v-list-item-content>
                        </template>
                        <div class="d-inline-flex pa-0">
                        </div>
                    </v-tooltip>
                </v-list-item>
            </v-list-item-group>
        </v-list>
        <template v-slot:append>
            <div class="pa-2">
                <v-btn color="error" block outlined @click="sair" title="Sair do Sistema">
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
                this.isLogin = name != "login" ? true : false;
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
                { text: "Sair", icon: "mdi-logout" },
            ],

            isLogin: false,
            get items() {
                return sidebarItems;
            },
        };
    },
    methods: {

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

#nav-border {
    border-right: 2px solid #f1f1f1;
    box-shadow: 4px 8px 4px -3px rgba(0, 0, 0, 0.25);
}

#items-sidebar:hover {
    background-color: rgba(45, 203, 115, 0.2);
}
</style>
  