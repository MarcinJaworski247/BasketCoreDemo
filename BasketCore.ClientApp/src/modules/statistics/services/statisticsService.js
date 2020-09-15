import axios from "../../../http-common";

class statisticsService {
    getStats(gameId) {
        if(gameId !== null)
            return axios.get(`/stats/getGameStats/${gameId}`);
    }
    getOpponentName(gameId) {
        if(gameId !== null)
            return axios.get(`/stats/getOpponentName/${gameId}`);
    }
    getPlayerStats(id, gameId) {
        if(id !== null && gameId !== null)
            return axios.get(`/stats/getPlayerStats/${id}/${gameId}`);
    }
    updatePlayerStats(data) {
        debugger
        return axios.put(`stats/updatePlayerStats`, data);
    }
    getAvgStats() {
        return axios.get(`/stats/getAvgStats`);
    }
    getPlayersToLookup() {
        return axios.get(`/player/getPlayersToLookup`);
    }
}

export default new statisticsService();