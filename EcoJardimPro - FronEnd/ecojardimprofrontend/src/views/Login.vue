<template>
    <v-container>
        <v-card flat>
            <v-row class="mb-6" justify="center" align="center">
                <v-col col="12" sm="6" md="6">
                    <v-img src="../../src/assets/images/ecojardimlogo.png"></v-img>
                </v-col>
                <v-col col="12" sm="6" offset-sm="0" md="6" offset-md="0">
                    <v-form @submit.stop.prevent="logar()">
                        <v-text-field color="#4CAF50" outlined v-model="login.userName" label="Login"></v-text-field>
                        <v-text-field color="#4CAF50" outlined type="password" v-model="login.password" label="Senha"></v-text-field>
                        <v-btn color="#4CAF50" type="submit">Entrar</v-btn>
                        <v-spacer></v-spacer>
                        <br>
                        <v-btn color="blue" @click="registroUsuarios()">Cadastre-se</v-btn>
                    </v-form>
                </v-col>
            </v-row>
        </v-card>
    </v-container>
</template>

<script lang="ts">

import { AlertaSimplesErro } from '@/components/shared/AlertService';
import NavigationHelper from '@/core/config/NavigationHelper';
import { setToken, removeToken } from '@/core/config/Token';
import { Login } from '@/core/models/Authentication';
import { LoginService } from '@/core/services/geral/LoginService';
import Vue from 'vue'

export default Vue.extend({
    name: 'Login',
    data() {
        return {
            login: new Login(),
            service: new LoginService(),

        }
    },
    methods: {
        logar() {
            setTimeout(() => {
                this.service.Salvar(this.login).then(
                    (res) => {
                        setToken(res.data.tokenDeAcesso);
                        this.atualizarUsuario();
                        NavigationHelper.navigate("Home");
                    },
                    (err) => {
                        removeToken();
                        AlertaSimplesErro("Ops, aconteceu um problema.", err);
                    }
                );
            }, 1500);
        },
        registroUsuarios(){
            this.$router.push({ name: 'Registro' });
        },
        atualizarUsuario() {
            this.$emit('atualizar-usuario');
        }
    }
})
</script>