import { GetterTree, MutationTree, ActionTree } from 'vuex';
import supportApi from '@/services/supportApi';
import User from '@/models/user';

class State {
  currentUser: User = new User();
}

const mutations = {
  SET_USER(state, item) {
    state.currentUser = item;
  },
} as MutationTree<State>;

const actions = {
  async show({ commit }, id: string) {
    try {
      const response = await supportApi.get(`getUser/${id}`);

      return response;
    } catch (error) {
      throw error.response;
    }
  },
} as ActionTree<State, unknown>;

const getters = {
} as GetterTree<State, unknown>;

export default {
  namespaced: true,
  state: new State(),
  mutations,
  actions,
  getters,
};
