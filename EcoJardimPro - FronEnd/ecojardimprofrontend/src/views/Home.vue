<template>
  <master-page titulo="Home" icone="mdi-home">
    <v-card height="700">
      <v-card-text>
      </v-card-text>
    </v-card>
  </master-page>
</template>

<script lang="ts">
import { parsePermissions } from '@/core/config/Permission';
import { getToken, decode } from '@/core/config/Token';
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

