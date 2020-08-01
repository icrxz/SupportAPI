<template>
  <v-container>
    <Breadcrumb :breadcrumbItems="breadcrumbItems" pageTitle="Search Ticket"/>

    <v-data-table
        :headers="headers"
        :items="desserts"
        :search="search"
    ></v-data-table>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue';
import Breadcrumb from '@/components/shared/Breadcrumbs.vue';

export default Vue.extend({
  name: 'SearchTicket',
  components: {
    Breadcrumb,
  },

  data: () => ({
    breadcrumbItems: [
      { text: 'Home', to: { name: 'Home' } },
      { text: 'Search', to: { name: 'Search' } },
    ],
  }),
});
</script>
