import Vue from "vue";
import Router from "vue-router";

Vue.use(Router);

export default new Router({
    mode: "history",
    routes: [
        {
            path: "/lineup",
            name: "lineup.index",
            component: () => import("./modules/lineup/views/Index.vue")
        },
        {
            path: "/games",
            name: "games",
            component: () => import("./modules/games/views/Index.vue")
        },
        {
            path: "/statistics",
            name: "statistics",
            component: () => import("./modules/statistics/views/Index.vue")
        },
        {
            path: `/statistics/edit/:gameId`,
            name: "statistics.edit",
            component: () => import("./modules/statistics/views/Edit.vue")
        }
    ]
});