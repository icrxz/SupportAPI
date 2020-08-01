<template>
  <v-app-bar
    app
    color="black"
    dark
    class="mb-0"
  >
    <v-app-bar-nav-icon></v-app-bar-nav-icon>
    <v-toolbar-title class="mr-5">SupportAPI</v-toolbar-title>

    <v-toolbar-items class="mx-0 px-0">
        <v-btn text class="text-none" :to="{ name: 'Home' }">Home</v-btn>
        <v-btn text class="text-none" :to="{ name: 'Search' }">Consultar</v-btn>
        <v-btn text class="text-none" :to="{ name: 'Create' }">Criar Tickets</v-btn>
    </v-toolbar-items>

    <v-spacer/>

    <v-btn text class="text-none">Logout</v-btn>
  </v-app-bar>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
});
</script>

<style scoped>
</style>
