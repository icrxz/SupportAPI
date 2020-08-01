import { GetterTree, MutationTree, ActionTree } from 'vuex';
import supportApi from '@/services/supportApi';
import Ticket from '@/models/ticket';

class State {
  ticketsList: Array<Ticket> = [];
}

const mutations = {
  SET_TICKETS(state, items) {
    state.ticketsList = items;
  },
} as MutationTree<State>;

const actions = {
  async index({ commit }) {
    try {
      const response = await supportApi.get('ticket/getTickets');

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
