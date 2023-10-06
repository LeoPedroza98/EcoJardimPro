<template>
    <v-container class="login-container">
        <v-row>
            <v-col cols="12" sm="12" :md="12">   
                <v-img src="../assets/logo.png" class="logo-image"></v-img>
            </v-col>
        </v-row>
        <v-card>
            <v-card-text class="form-card">
            <v-form >
                <v-row>
                    <v-col cols="12" sm="12" :md="12">
                        <v-text-field
                        variant="outlined"
                        label="Nome de usuário ou Email"
                        required
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="12" :md="12">
                        <v-text-field
                        variant="outlined"
                        label="Senha"
                        type="password"
                        required
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn color="#2f4538" @click="$router.push({ name: 'home' })">Entrar</v-btn>
            </v-form>
            </v-card-text>
        </v-card>
    </v-container>
  </template>

<script lang="ts">

import { defineComponent } from 'vue'


export default defineComponent({
    methods:{

    }
})

</script>
<style scoped>
.login-container {
    display: grid;
    grid-template-columns: 1fr 1fr;
    border-radius: 5px;
    width: 100%;
    height: 100%;
    background-color: #F1F1F1;
  
}
.v-card-container{
    width: 100%;
    height: 100%;
    background-color: #F1F1F1 !important;
}

.form-card { /* Estilo para o v-card do formulário */
    width: 100%;
    height: 100%;
    margin-top: 30%; /* Adicione um espaço em branco na parte superior */
}

.logo-image {
    width: 100%; /* Defina o tamanho da imagem para 100% do v-card */
    height: auto; /* Mantenha a proporção da imagem */
}

.botao_submit{
    color: #2f4538 !important;
}
</style>