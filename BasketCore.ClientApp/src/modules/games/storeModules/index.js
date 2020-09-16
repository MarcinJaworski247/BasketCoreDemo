import { getField, updateField } from 'vuex-map-fields';
import service from "../services/gamesService.js";
import { createStore } from 'devextreme-aspnet-data-nojquery';
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
    },
    loaded: null    
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
    },
    setLoaded: (state, loaded) => {
        state.loaded = loaded;
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
    loaded: () => { return false; },
    setDetails: ({commit}, id) => {
        service.getGameDetails(id)
            .then(response => {
                commit('setDetails', response.data);
            })
    },
    editGame: ({state, dispatch}) => {
        service.updateGame(state.editForm)
            .then(() => {
                dispatch('setGames')
            });
    },
    deleteGame: ({state, dispatch}) => {
        service.deleteGame(state.idToDelete).then(() => {
            dispatch('setGames')
        });
    },
    addGame: ({state, dispatch}) => {
        service.addGame(state.addForm).then(() => {
            dispatch('setGames')
        });
    },
    setGames: ({commit }) => {
        let store = createStore({
            key: 'id',
            loadUrl: `https://localhost:44377/api/game/getGames`
        });
        let dataSource = {
            store: store,
            onLoadingChanged: function(isLoading) {
                if(!isLoading) {
                    if (state.loaded != null) {
                        state.loaded;
                    }
                }
            }
        }
        commit('setGames', dataSource);
            
    },
    setGameTypes: ({commit}) => {
        service.getGameTypes()
            .then(response => {
                commit('setGameTypes', response.data);
            });
    },
    setLoaded: ({ commit }, loaded) => {
        commit('setLoaded', loaded);
    }
}

export default { state, getters, mutations, actions, namespaced };