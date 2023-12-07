<template>
    <v-container>
    </v-container>
</template>

<script lang="ts">
import { IAuthUserModel } from "@/models/Authentication/AuthUser";
import { decode, getToken } from "../../config/Token";

export default {
    name: 'Home',
    data() {
        return {
            usuario: null
        }
    },
    mounted() {
        this.atualizarInformacoesUsuario();
        this.$root.$on('atualizar-usuario', this.atualizarInformacoesUsuario);
    },
    methods: {
        atualizarInformacoesUsuario() {
            const token = getToken();
            if (token) {
                this.usuario = decode(token);
            }
        },
    }
}
</script>