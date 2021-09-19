<template>
  <v-app>
    <v-main>
      <FilmShow />
    </v-main>
  </v-app>
</template>

<script>
import FilmShow from "./components/film-show";
export default {
  name: "App",

  components: {
    FilmShow
  },

  data: () => ({
    //
  })
};
</script>
