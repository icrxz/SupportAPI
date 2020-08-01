<template>
  <v-container fluid class="home mb-5">
    <Breadcrumb :breadcrumbItems="breadcrumbItems"> </Breadcrumb>

    <v-row>
        <v-col class="text-center">
            <h2>SupportAPI</h2>
            <p>Seu Portal de Atendimento Online</p>
        </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Breadcrumb from '@/components/shared/Breadcrumbs.vue';

export default {
  name: 'Home',

  components: {
    Breadcrumb,
  },

  data: () => ({
    breadcrumbItems: [
      {
        text: 'Home',
        to: { name: 'Home' },
        exact: true,
      },
    ],
  }),
};
</script>
