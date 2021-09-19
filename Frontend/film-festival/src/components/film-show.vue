<template>
  <v-container>
    <v-row class="text-center"></v-row>
    <v-tabs v-model="tabs" active-class="horizontalni-tab-active" class="pa-10">
      <v-tab class="horizontalni-tab">{{ "Film" }}</v-tab>
      <v-tab class="horizontalni-tab">{{ "Show" }}</v-tab>
    </v-tabs>
    <v-tabs-items v-model="tabs">
      <v-tab-item eager :key="0">
        <v-row>
          <v-text-field
            class="pa-10"
            label="Search for film...."
            hide-details="auto"
            v-model="inputs.movieSearch"
            v-on:keyup="moviesSearch()"
          ></v-text-field>
        </v-row>
        <v-row class="pa-10">
          <DataTable :show="movie" />
        </v-row>
      </v-tab-item>
      <v-tab-item eager :key="1">
        <v-row>
          <v-text-field
            class="pa-10"
            label="Search for show...."
            hide-details="auto"
            v-model="inputs.showSearch"
            v-on:keyup="showsSearch()"
          ></v-text-field>
        </v-row>
        <v-row class="pa-10">
          <DataTable :show="show" />
        </v-row>
      </v-tab-item>
    </v-tabs-items>
    <h1 style="text-align: center;">Rate movie</h1>
    <v-data-table
      style="width: 100%; margin: 0 auto"
      v-if="show"
      :headers="headers"
      :items="movie.items"
      :items-per-page="5"
      class="elevation-1"
    >
      <template v-slot:item.rateMovie="props">
        <v-rating
          v-model="props.item.rateMovie"
          background-color="indigo lighten-3"
          color="indigo"
          @input="saveRating(props.item.rateMovie, props.item.id)"
        ></v-rating>
      </template>
    </v-data-table>
    <v-snackbar v-model="snackbar" :timeout="timeout">
      {{ text }}
      <template v-slot:action="{ attrs }">
        <v-btn color="blue" text v-bind="attrs" @click="snackbar = false">Close</v-btn>
      </template>
    </v-snackbar>
  </v-container>
</template>

<script>
import debounce from "lodash.debounce";
import DataTable from "./data-table";
export default {
  name: "film-show",
  Component: {
    debounce
  },
  components: {
    DataTable
  },
  data() {
    return {
      tabs: 0,
      dialog: false,
      movie: null,
      show: null,
      axios: require("axios"),
      snackbar: false,
      text: "Movie raiting successfully saved!",
      timeout: 2000,
      headers: [
        {
          text: "Id",
          value: "id"
        },
        {
          text: "Title",
          value: "title"
        },
        {
          text: "Rate movie",
          value: "rateMovie"
        }
      ],
      inputs: {
        movieSearch: null,
        showSearch: null
      }
    };
  },
  created() {
    this.getMovie();
    this.getShow();
  },
  methods: {
    saveRating(r, i) {
      var that = this;
      this.axios
        .post("http://localhost:2201/movie/raiting", {
          raiting: r,
          id: i
        })
        .then(function(response) {
          console.log("r", response);
          that.snackbar = true;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    getMovie() {
      var that = this;
      this.axios
        .get("http://localhost:2201/movie/movies", {
          params: {
            filter: this.inputs.movieSearch
          }
        })
        .then(function(response) {
          that.movie = response.data;
        })
        .catch(function(error) {
          // handle error
          console.log(error);
        })
        .then(function() {});
    },
    getShow() {
      var that = this;
      this.axios
        .get("http://localhost:2201/show/shows", {
          params: {
            filter: this.inputs.showSearch
          }
        })
        .then(function(response) {
          that.show = response.data;
        })
        .catch(function(error) {
          // handle error
          console.log(error);
        })
        .then(function() {});
    },

    moviesSearch: debounce(function() {
      if (
        (this.inputs.movieSearch && this.inputs.movieSearch.length >= 2) ||
        this.inputs.movieSearch.length == 0
      ) {
        this.getMovie();
      }
    }, 500),
    showsSearch: debounce(function() {
      if (
        (this.inputs.showSearch && this.inputs.showSearch.length >= 2) ||
        this.inputs.showSearch.length == 0
      ) {
        this.getShow();
      }
    }, 500)
  }
};
</script>
