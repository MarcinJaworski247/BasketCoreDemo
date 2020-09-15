import { getField, updateField } from 'vuex-map-fields';
import service from "../services/statisticsService.js";
import router from "@/router"
const namespaced = true;

const state = {
    stats: [],
    editForm: {
        name: '',
        playerId: null,
        gameId: null,
        points: null,
        assists: null,
        rebounds: null,
        steals: null,
        blocks: null,
        fauls: null
    },
    opponentName: ''
}

const getters = {
    getField,
    getEditForm: (state) => {
        return state.editForm;
    },
    getStats: (state) => {
        return state.players;
    },
    getOpponentName: (state) => {
        return state.opponentName;
    }  
}

const mutations = {
    updateField,
    setDetails: (state, payload) => {
        state.editForm.name = payload.name;
        state.editForm.playerId = payload.playerId;
        state.editForm.gameId = payload.gameId;
        state.editForm.points = payload.points;
        state.editForm.assists = payload.assists;
        state.editForm.rebounds = payload.rebounds;
        state.editForm.steals = payload.steals;
        state.editForm.blocks = payload.blocks;
        state.editForm.fauls = payload.fauls;
    },
    setStats: (state, payload) => {
        state.stats = payload;
    },
    resetEditForm: (state) => {
        state.editForm.name = null;
        state.editForm.playerId = null;
        state.editForm.gameId = null;
        state.editForm.points = null;
        state.editForm.assists = null;
        state.editForm.rebounds = null;
        state.editForm.steals = null;
        state.editForm.blocks = null;
        state.editForm.fauls = null;
    },
    setOpponentName: (state, payload) => {
        state.opponentName = payload;
    }
}

const actions = {
    setDetails: ({commit}, id) => {
        service.getPlayerStats(id, router.currentRoute.params.gameId)
            .then(response => {
                commit('setDetails', response.data);
            })
    },
    editStats: ({state}) => {
        service.updatePlayerStats(state.editForm);
    },
    setStats: ({commit}, gameId) => {
        service.getStats(gameId)
            .then(response => {
                commit('setStats', response.data);
            });
    },
    setOpponentName({commit}, gameId) {
        service.getOpponentName(gameId)
        .then(response => {
            commit('setOpponentName', response.data)
        });
    },
}

export default { state, getters, mutations, actions, namespaced };
