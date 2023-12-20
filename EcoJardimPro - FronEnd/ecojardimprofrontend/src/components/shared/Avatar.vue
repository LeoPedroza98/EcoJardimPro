<template>
    <v-avatar class="avatar">
        <img v-if="src" :src="`data:image/jpeg;base64,${src}`">
        <span v-else style="color: white; font-size: 20px">{{iniciais}}</span>
    </v-avatar>
</template>

<script lang="ts">
import { PageBase } from '@/core/models/shared';
import { Vue, Component, Watch, Prop } from 'vue-property-decorator';

@Component
export default class MasterPage extends PageBase{
    @Prop() private src!: string;
    @Prop() private nome!: string;

    iniciais: string = "";

    created() {
        this.GetIniciais();   
    }

    GetIniciais(){
        var rawTeste = this.nome.split(" ");
        this.iniciais += rawTeste[0].trim().charAt(0);
        this.iniciais += rawTeste[rawTeste.length - 1].trim().charAt(0);
    }
}
</script>

<style lang="scss">
  .avatar{
    background: var(--v-secondary-base);
    border-radius: 50%;
  }
</style>