import axios from "../../../http-common";

class gamesService {
    getGames() {
        return axios.get("/game/getGames");
    }
    deleteGame(id) {
        if (id !== null)
            return axios.delete(`/game/deleteGame/${id}`);
    }
    getGameDetails(id) {
        if(id !== null)
            return axios.get(`/game/getGameDetails/${id}`);
    }
    updateGame(data) {
        return axios.put(`/game/updateGame`, data);
    }
    addGame(data) {
        debugger
        return axios.put(`/game/addGame`, data);
    }
    getGameTypes() {
        return axios.get("/game/getGameTypes");
    }
}

export default new gamesService();