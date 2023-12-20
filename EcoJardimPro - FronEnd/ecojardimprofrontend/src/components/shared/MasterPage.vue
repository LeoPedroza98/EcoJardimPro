<template>
  <v-app>

    <!-- IMAGEM CABEÇALHO -->
    <v-img src="@/assets/images/ecojardimproheader.jpeg" class="headerImg"/>

    <!-- CABEÇALHO -->
    <div class="pageHeader">

      <v-btn class="menuButton" icon small color="black" depressed @click="drawer = !drawer" style="margin-right: 10px">
        <v-icon>mdi-menu</v-icon>
      </v-btn>

      <v-spacer/>

      <!-- MENU USUARIO -->

      <!-- ACOES LISTA -->
      <div class="actions">

        <div style="color: black; font-size: 30px;">

          <v-icon color="black" style="margin-right: 10px; font-size: 28px !important">{{icone}}</v-icon>
          <span>{{titulo}}</span> <br/>

          <breadCrumb-component divider="-"/>

        </div>

        <v-spacer/>

        <slot name="acoes"/>

      </div>

    </div>

    <!-- CONTEUDO -->
    <div class="pageContent">
      <v-card>
        <slot/>
      </v-card>
    </div>

    <!-- MENU LATERAL -->
    <v-navigation-drawer class="drawerMenu" fixed v-model="drawer" temporary :width=" $vuetify.breakpoint.smAndDown ? '70vw' : '300px'" dark>

      <v-subheader class="ml-2 mt-1">MENU</v-subheader>

      <v-divider/>

      <v-list nav dense class="pa-0 navDrawerMenu">

        <!-- Geral -->
        <v-list-group prepend-icon="mdi-ballot-outline">
          <template v-slot:activator>
            <v-list-item-title>Geral</v-list-item-title>
          </template>
          <div v-for="(item, index) in geralMenuButtons" :key="index" style="padding: 2px 10px 2px 10px">
            <v-list-item :to="item.path" :disabled="item.restrito" style="padding-left: 10px; border-radius: 10px">
              <v-list-item-title>{{item.name}}</v-list-item-title>
              <v-list-item-icon><v-icon>{{item.icon}}</v-icon></v-list-item-icon>
            </v-list-item>
          </div>
        </v-list-group>

      </v-list>

      <template v-slot:append>

        <v-list-item @click="logout()" style="padding-left: 30px">
          <v-list-item-icon>
            <v-icon>mdi-logout</v-icon>
          </v-list-item-icon>
          <v-list-item-title>Sair</v-list-item-title>
        </v-list-item>

      </template>

    </v-navigation-drawer>

  </v-app>
</template>

<script lang="ts">
import Vue, { PropType } from 'vue'
import { PageBase } from '@/core/models/shared';

export default Vue.extend({
  props: {
    icone: {
      type: String as PropType<string>,
      required: true,
    },
    titulo: {
      type: String as PropType<string>,
      required: true,
    },
  },
  data() {
    return {
      drawer: false,
      dialogAlterarSenha: false,
      geralMenuButtons: [
        { name: 'Clientes', icon: 'mdi-account-group-outline', path:'/geral/clientes', restrito: false },
        { name: 'Projetos', icon: 'mdi-handshake', path: '/geral/projetos', restrito: false },
        { name: 'Orçamentos', icon: 'mdi-account-cash', path: '/geral/orcamentos', restrito: false },
        { name: 'Serviços', icon: 'mdi-account-wrench', path: '/geral/servicos', restrito: false },
        {name:'Usuário', icon:'mdi-account', path:'/geral/usuario', restrito: false},
      ],
    };
  },
  methods: {
    logout() {
      localStorage.clear();
      this.$vuetify.theme.dark = false;
      this.$router.push({ name: 'Login' });
    },
  },
});
</script>

<style lang="scss">

 

.drawerMenu{
  background:#ffffff ;
}

  .navDrawerMenu{
    .v-list-item--active {
      color: #4CAF50 !important;
    }
  }

  .menuEmpresaLogo{
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 30px 0px 30px 0px;
    background-color: white;
    border-radius: 0px 0px 25px 25px;
    opacity: 1 !important;
    img{
      max-width: 160px;
      max-height: 165px;
    }
  }

  .menuList{
    width: 300px;
    .user{
      margin: 0px 0px 10px 10px;
      display: inline-flex;
      padding: 10px;
      display: flex;
      justify-content: flex-start;
      align-items: center;
      .avatar{
        margin-right: 10px !important;
      }
    }
  }

</style>
