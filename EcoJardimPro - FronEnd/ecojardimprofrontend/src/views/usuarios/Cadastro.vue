<template>
    <v-container>
        <v-card flat>
            <v-row class="mb-6" justify="center" align="center">
                <v-col col="12" sm="6" md="6">
                    <v-img src="../../../src/assets/images/ecojardimlogo.png"></v-img>
                </v-col>
                <v-col col="12" sm="6" offset-sm="0" md="6" offset-md="0">
                    <v-form ref="form" v-model="valid" lazy-validation>
                        <v-text-field color="#4CAF50" outlined v-model="item.nome" label="Nome"></v-text-field>
                        <v-text-field color="#4CAF50" outlined v-model="item.sobrenome" label="Sobrenome"></v-text-field>
                        <v-text-field color="#4CAF50" outlined v-model="item.userName"
                            label="Nome para o Login" :rules="fieldRules"></v-text-field>
                        <v-text-field color="#4CAF50" outlined v-model="item.email" label="Email"></v-text-field>
                        <v-text-field type="password" color="#4CAF50" outlined v-model="item.password"
                            label="Password" :rules="fieldRules"></v-text-field>
                        <v-btn color="#4CAF50" type="submit" @click="Salvar()">Registrar</v-btn>
                        <v-spacer></v-spacer>
                        <br>
                        <v-btn color="red" type="submit" @click="VoltarLogin()">Voltar ao Login</v-btn>
                    </v-form>
                </v-col>
            </v-row>
        </v-card>
    </v-container>
</template>

<script lang="ts">

import { AlertaSimplesErro, AlertaSimplesResponse } from '@/components/shared/AlertService';
import NavigationHelper from '@/core/config/NavigationHelper';
import { Usuario } from '@/core/models/geral';
import { UsuarioService } from '@/core/services/geral';
import Vue from 'vue'

export default Vue.extend({
    name: 'Registro',
    data() {
        return {
            item: new Usuario(),
            service: new UsuarioService(),
            valid: true,
            fieldRules: [(v: any) => !!v || "Campo obrigatório"] as ((v: any) => string)[],
            $refs: {
                form: HTMLFormElement,
                file: HTMLFormElement,
            },
        }
    },
    methods: {
        Salvar() {
            if (this.$refs.form.validate()) {
                this.service.Salvar(this.item).then(
                    res => {
                        AlertaSimplesResponse("Aviso", res);
                        this.$router.push({ name: 'Login' });
                    },
                    err => {
                        AlertaSimplesErro("Aviso", err);
                    }
                );
            }
        },
        VoltarLogin(){
            this.$router.push({ name: 'Login' });
        }
    }
})
</script>