<template>
  <div class="container-logo">
    <h1>TESTE POW</h1>
  </div>
</template>

<script lang="ts">
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
        this.user = decode(token);
      }
    },
  }
});
</script>
<style scoped>
.container-logo {
    margin-top: 100px;
    width: 50%;
    /* Valor da Largura */
    width: 100%;
    height: 100%;
    text-align: center;
}
</style>