<template>
  <div id="app">
    <link rel="stylesheet" 
        href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" 
        integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ" 
        crossorigin="anonymous">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <span class="navbar-brand">BasketCore <i class="fas fa-basketball-ball"></i></span>
      <div class="navbar-nav ml-4">
        <ul class="navbar-nav">
          <li class="nav-item ml-4">
            <router-link :to="{ name: 'lineup.index' }" class="nav-link">Zawodnicy <i class="fas fa-users"></i></router-link>
          </li>
          <li class="nav-item ml-4">
            <router-link :to="{ name: 'games' }" class="nav-link">Mecze <i class="fas fa-flag"></i></router-link>
          </li>
          <li class="nav-item ml-4">
            <router-link :to="{ name: 'statistics' }" class="nav-link">Statystyki <i class="fas fa-chart-bar"></i></router-link>
          </li>
        </ul>
      </div>
    </nav>

    <div class="container mt-3">
      <router-view />
    </div>
  </div>
</template>

<script>

export default {
  name: 'App',
  components: {
  }
}
</script>


