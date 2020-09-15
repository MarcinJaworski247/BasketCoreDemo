import Vue from 'vue'
import Vuex from 'vuex'
import lineupStore from '../modules/lineup/storeModules/index'
import gamesStore from '../modules/games/storeModules/index'
import statsStore from '../modules/statistics/storeModules/edit'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        lineupStore, gamesStore, statsStore
    }
})