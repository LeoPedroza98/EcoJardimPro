
<template>
<v-app id="inspire">
    <v-system-bar>
    <v-spacer></v-spacer>
    </v-system-bar>

    <v-navigation-drawer v-model="drawer">
    <v-sheet style="background-color: #f1f1f1 !important;"
        color="grey-lighten-4"
        class="pa-4"
    >
        <v-avatar
        class="mb-4"
        color="grey-darken-1"
        size="64"
        ></v-avatar>

        <div> 
            <h1 style="color: #2f4538;">Gestor</h1>
        </div>
    </v-sheet>

    <v-divider></v-divider>

    <v-list>
        <v-list-item
        v-for="[icon, text] in links"
        :key="icon"
        :prepend-icon="icon"
        :title="text"
        link
        ></v-list-item>
    </v-list>
    </v-navigation-drawer>

    <v-main>
    <v-container
        class="py-8 px-6"
        fluid
    >
        <v-row>
        <v-col
            v-for="card in cards"
            :key="card"
            cols="12"
        >
            <v-card>
            <v-list lines="two">
                <v-list-subheader :title="card"></v-list-subheader>

                <template v-for="n in 6" :key="n">
                <v-list-item>
                    <template v-slot:prepend>
                    <v-avatar color="grey-darken-1"></v-avatar>
                    </template>

                    <v-list-item-title  :title="`Message ${n}`"></v-list-item-title>

                    <v-list-item-subtitle title="Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nihil repellendus distinctio similique"></v-list-item-subtitle>
                </v-list-item>

                <v-divider
                    v-if="n !== 6"
                    :key="`divider-${n}`"
                    inset
                ></v-divider>
                </template>
            </v-list>
            </v-card>
        </v-col>
        </v-row>
    </v-container>
    </v-main>
</v-app>
</template>

<script lang="ts" setup>
  import { ref } from 'vue'

  const cards = ['Agenda']
  const links = [
    ['mdi-account-search-outline', 'Clientes'],
    ['mdi-cog-outline', 'Configuração'],
  ]

  const drawer = ref(null)
</script>
