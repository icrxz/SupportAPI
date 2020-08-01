<template>
  <v-container>
    <Breadcrumb :breadcrumbItems="breadcrumbItems"/>
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
      { text: 'Create', to: { name: 'Create' } },
    ],
  }),
});
</script>
