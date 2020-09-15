import { getField, updateField } from 'vuex-map-fields';
import service from "../services/gamesService.js";
const namespaced = true;

const state = {
    idToDelete: null,
    games: [],
    gameTypes: [],
    addForm: {
        add_opponentname: '',
        add_date: null,
        add_court: '',
        add_gametype: null
    },
    editForm: {
        opponentName: '',
        date: null,
        court: '',
        gameType: null,
        id: null
    }    
}

const getters = {
    getField,
    getEditForm: (state) => {
        return state.editForm;
    },
    getAddForm: (state) => {
        return state.addForm;
    },
    getGames: (state) => {
        return state.games;
    },
    getGameTypes: (state) => {
        return state.gameTypes;
    }
}

const mutations = {
    updateField,
    setDetails: (state, payload) => {
        state.editForm.opponentName = payload.opponentName;
        state.editForm.date = payload.date;
        state.editForm.court = payload.court;
        state.editForm.gameType = payload.gameType;
        state.editForm.id = payload.id;

    },
    setGames: (state, payload) => {
        state.games = payload;
    },
    setGameTypes: (state, payload) => {
        state.gameTypes = payload;
    },
    resetEditForm: (state) => {
        state.editForm.opponentName = null;
        state.editForm.date = null;
        state.editForm.court = null;
        state.editForm.gameType = null;
        state.editForm.id = null;
    },
    resetAddForm: (state) => {
        state.addForm.add_opponentname = null;
        state.addForm.add_date = null;
        state.addForm.add_court = null;
        state.addForm.add_gametype = null;
    }
}

const actions = {
    setDetails: ({commit}, id) => {
        service.getGameDetails(id)
            .then(response => {
                commit('setDetails', response.data);
            })
    },
    editGame: ({state}) => {
        service.updateGame(state.editForm);
    },
    deleteGame: ({state}) => {
        service.deleteGame(state.idToDelete);
    },
    addGame: ({state}) => {
        service.addGame(state.addForm);
    },
    setGames: ({commit }) => {
        service.getGames()
            .then(response => {
                commit('setGames', response.data);
            });
    },
    setGameTypes: ({commit}) => {
        service.getGameTypes()
            .then(response => {
                commit('setGameTypes', response.data);
            });
    },
}

export default { state, getters, mutations, actions, namespaced };