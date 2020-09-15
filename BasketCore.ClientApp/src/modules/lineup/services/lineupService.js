import axios from "../../../http-common";

class lineupService {
    getPlayers() {
        return axios.get("/player/getPlayers");
    }
    deletePlayer(id) {
        if (id !== null)
            return axios.delete(`/player/deletePlayer/${id}`);
    }
    getPlayerDetails(id) {
        if(id !== null)
            return axios.get(`/player/getPlayerDetails/${id}`);
    }
    updatePlayer(data) {
        return axios.put(`/player/updatePlayer`, data);
    }
    addPlayer(data) {
        return axios.put(`/player/addPlayer`, data);
    }
    getPositions() {
        return axios.get("/player/getPositions");
    }

}

export default new lineupService();