<template>
  <v-container class="fill-height" fluid>
    <v-row align="center" justify="center">
      <v-col cols="12" xs="12" sm="8" md="5">
        <v-card class="py-8 elevation-12">
          <v-row class="mb-6" justify="center">
            <img src="@/assets/logo.svg" width="15%">
          </v-row>

          <v-row justify="center">
            <v-toolbar-title>Bem-Vindo</v-toolbar-title>
          </v-row>

          <v-card-text>
            <v-form ref="form" v-model="formValid">
              <v-text-field
                v-model="user.email"
                label="Email"
                :rules="rules.email"
                type="email"
                autofocus
              ></v-text-field>

              <v-text-field
                v-model="user.password"
                :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
                :type="show ? 'text' : 'password'"
                label="Senha"
                :rules="rules.password"
                @click:append="show = !show"
              ></v-text-field>
            </v-form>
          </v-card-text>

          <div>
            <v-row justify="center">
              <v-btn
              color="success"
              large
              class="mb-5"
              @click="handleLogin">
                Acessar
              </v-btn>
            </v-row>

            <v-row justify="center">
              <v-btn text>
                Esqueceu a senha?
              </v-btn>
            </v-row>
          </div>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'Login',

  data: () => ({
    formValid: false,
    rules: {
      email: [
        (v: string) => !!v || 'Email necessário',
      ],
      password: [
        (v: string) => !!v || 'Senha necessária',
      ],
    },
    show: false,
    user: {
      email: null,
      password: null,
    },
  }),

  methods: {
    handleLogin() {
      this.$router.push({ name: 'Home' });
    },
  },
});
</script>
