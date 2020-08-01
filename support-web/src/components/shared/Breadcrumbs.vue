<template>
  <v-row class="mb-4 grey lighten-4">
    <v-breadcrumbs :items="breadcrumbItems"></v-breadcrumbs>
  </v-row>
</template>

<script lang='ts'>
import Vue from 'vue';

export default Vue.extend({
  name: 'Breadcrumbs',
  props: ['breadcrumbItems', 'pageTitle'],
});
</script>
