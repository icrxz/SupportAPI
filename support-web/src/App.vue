<template>
  <v-app>
    <Toolbar v-if="hasHeader"/>

    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';
import Toolbar from '@/components/shared/Toolbar.vue';

export default Vue.extend({
  name: 'App',

  components: {
    Toolbar,
  },

  data: () => ({ hasHeader: true }),

  watch: {
    $route() {
      this.hasHeader = this.$route.name !== 'Login';
    },
  },
});
</script>
