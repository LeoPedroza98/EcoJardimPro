<template>
    <v-breadcrumbs class="breadcrumb" :items="rota" :divider="divider">
        <template v-slot:item="{ item }">
            <v-breadcrumbs-item :href="item.href">
                <span :style="item.href ? 'text-decoration: underline;' : ''" >{{item.text}}</span>
            </v-breadcrumbs-item>
        </template>
    </v-breadcrumbs>
</template>

<script lang="ts">
import { PageBase } from '@/core/models/shared';
import { Vue, Component, Watch, Prop } from 'vue-property-decorator';

@Component
export default class MasterPage extends PageBase{
    @Prop() private divider!: string;
    @Prop() private color!: string;

    rota: any[] = [];

    mounted() {
        document.documentElement.style.setProperty('--color', this.color);

        let rota = this.$route.path.split("/");

        if(this.$route.path.split("/")[1] != 'home'){
            this.rota.unshift({text: "Home", href: '/home'});
            this.rota.push({text: rota[rota.length - 1].charAt(0).toUpperCase() + rota[rota.length - 1].slice(1), href: this.$route.path})
        }
        else{
            this.rota.unshift({text: "Home", href: '/home'});
        }
    }
}
</script>

<style lang="scss">

    :root{
        --color: white
    }

    .breadcrumb{

        .v-breadcrumbs__divider{
            color: var(--color) !important;
        }
        .v-breadcrumbs__item{
            color: var(--color) !important;
        }

    }

</style>