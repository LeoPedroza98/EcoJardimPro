<template>
  <v-app>
    <sidebar v-model="abrirMenu"  />
    <v-main>
      <v-container class="containerPrincipal" fluid>
        <transition name="fade" mode="out-in">
          <router-view />
        </transition>
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';
import { getToken, getModoNoturno } from './config/Token';

export default Vue.extend({
  name: 'App',
  mounted() {
    if (getToken()) {        
    }     
  },
  data() {
    return {
      abrirMenu: false,
    };
  },
});
</script>
<style>
.fade-enter-active,
.fade-leave-active {
  transition-duration: 0.2s;
  transition-property: opacity;
  transition-timing-function: ease;
}

.fade-enter,
.fade-leave {
  opacity: 0;
}

.swal2-popup {
  font-family: Arial, Helvetica, sans-serif !important;
}

@media screen and (max-width: 760px) {

  .containerPrincipal {
    padding: 0;

  }
}
</style>
