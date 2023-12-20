<template>
    <v-text-field class="searchList mx-1" v-model="localSearch" prepend-inner-icon="mdi-magnify" label="Pesquisa rápida" clearable single-linehide-details @change="Mudou()" hide-details/>
</template>

<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";

@Component
export default class TextSearch extends Vue {
    @Prop() private search!: string;
    
    localSearch: string = '';

    Mudou(){
        this.$emit('update:search', this.localSearch);
        this.$emit("mudou");
    }
}

</script>