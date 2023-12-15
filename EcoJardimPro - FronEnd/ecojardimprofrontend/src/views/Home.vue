<template>
  <div class="container-logo">
    <v-card>
      <h1>Projeto de bloco - Desenvolvido por Leonardo Pedroza de Faria</h1>
      <h2>EcoJardimPro</h2>
      <v-row>
        <v-col sm="12" col="12" md="12">
          <v-img src="../../src/assets/ecojardimlogo.png"></v-img>
        </v-col>
      </v-row>
    </v-card>
  </div>
</template>

<script lang="ts">
import { parsePermissions } from '@/config/Permission';
import { getToken, decode } from '@/config/Token';
import Vue from 'vue'

export default Vue.extend({
  name: 'Home',
  data() {
    return {
      user: null
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
      if (typeof token === 'string') {
        this.user = decode(token);
        const permissions = parsePermissions(token);
      }
    }
  },
  }
});
</script>
<style scoped>
.container-logo {
    margin-top: 100px;
    width: 50%;
    width: 100%;
    height: 100%;
    text-align: center;
}
</style>