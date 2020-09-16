import { getField, updateField } from 'vuex-map-fields';
import service from "../services/lineupService.js";
import { createStore } from 'devextreme-aspnet-data-nojquery';

const namespaced = true;

const state = {
    editForm: {
        firstName: '',
        lastName: '',
        height: null,
        weight: null,
        birthDate: null,
        position: null,
        number: null,
        id: null
    },
    addForm: {
        add_firstName: '',
        add_lastName: '',
        add_height: null,
        add_weight: null,
        add_birthDate: null,
        add_position: null,
        add_number: null
    },
    players: [],
    positions: [],
    idToDelete: null,
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
    getPlayers: (state) => {
        return state.players;
    },
    getPositions: (state) => {
        return state.positions;
    }
}

const mutations = {
    updateField,
    setDetails: (state, payload) => {
        state.editForm.firstName = payload.firstName;
        state.editForm.lastName = payload.lastName;
        state.editForm.height = payload.height;
        state.editForm.weight = payload.weight;
        state.editForm.birthDate = payload.birthDate;
        state.editForm.position = payload.position;
        state.editForm.number = payload.number;
        state.editForm.id = payload.id;
    },
    setPositions: (state, payload) => {
        state.positions = payload;
    },
    setPlayers: (state, payload) => {
        state.players = payload;
    },
    resetEditForm: (state) => {
        state.editForm.firstName = null;
        state.editForm.lastName = null;
        state.editForm.height = null;
        state.editForm.weight = null;
        state.editForm.birthDate = null;
        state.editForm.position = null;
    },
    resetAddForm: (state) => {
        state.addForm.add_firstName = null;
        state.addForm.add_lastName = null;
        state.addForm.add_height = null;
        state.addForm.add_weight = null;
        state.addForm.add_birthDate = null;
        state.addForm.add_position = null;
    },
    setLoaded: (state, loaded) => {
        state.loaded = loaded;
    }
}

const actions = {
    loaded: () => { return false; },
    setDetails: ({commit}, id) => {
        service.getPlayerDetails(id)
            .then(response => {
                commit('setDetails', response.data);
            })
    },
    editPlayer: ({state, dispatch}) => {
        service.updatePlayer(state.editForm)
            .then(() => {
                dispatch('setPlayers')
            });
    },
    setPlayers: ({commit }) => {
        let store = createStore({
            key: 'id',
            loadUrl: `https://localhost:44377/api/player/getPlayers`
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
        commit('setPlayers', dataSource); 
    },
    setPositions: ({commit}) => {
        service.getPositions()
            .then(response => {
                commit('setPositions', response.data);
            });
    },
    deletePlayer: ({state, dispatch}) => {
        service.deletePlayer(state.idToDelete)
            .then(() => {
                dispatch('setPlayers')
            });
    },
    addPlayer: ({state, dispatch}) => {
        service.addPlayer(state.addForm)
            .then(() => {
                dispatch('setPlayers')
            });
    },
    setLoaded: ({ commit }, loaded) => {
        commit('setLoaded', loaded);
    }
}



export default { state, getters, mutations, actions, namespaced };