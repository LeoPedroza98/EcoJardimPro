<template>
    <v-container>
        <v-card flat>
            <v-row class="mb-6" justify="center" align="center">
                <v-col col="12" sm="6" md="6">
                    <v-img src="../../src/assets/ecojardimlogo.png"></v-img>
                </v-col>
                <v-col col="12" sm="6" offset-sm="0" md="6" offset-md="0">
                    <v-form @submit.stop.prevent="logar()">
                        <v-text-field variant="outlined" v-model="login.userName" label="Login"></v-text-field>
                        <v-text-field variant="outlined" type="password" v-model="login.password" label="Senha"></v-text-field>
                        <v-btn type="submit">Entrar</v-btn>
                    </v-form>
                </v-col>
            </v-row>
        </v-card>
    </v-container>
</template>
<script lang="ts">
import Login from "../models/usuario/Login";
import { LoginService } from "../services/LoginService";
import {
  setToken,
  removeToken,
  removeModoNoturno,
  setModoNoturno,
} from "../config/Token";
import NavigationHelper from "../helpers/NavigationHelper";
import { AlertaSimplesErro } from "../helpers/MensagemHelper";
export default {
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
                this.service.Post(this.login).then(
                    (res) => {
                        setToken(res.data.tokenDeAcesso);
                        this.atualizarUsuario();
                        NavigationHelper.navigate("home");
                    },
                    (err) => {
                        removeToken();
                        AlertaSimplesErro("Ops, aconteceu um problema.", err);
                    }
                );
            }, 1500);
        },
        atualizarUsuario() {
            this.$emit('atualizar-usuario');
        }
    }
}
</script>