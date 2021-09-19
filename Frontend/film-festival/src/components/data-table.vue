<template>
  <v-data-table
    style="width: 100%"
    v-if="show"
    :headers="headers"
    :items="show.items"
    :items-per-page="10"
    class="elevation-1"
  >
    <template v-slot:item.releaseDate="props">
      <span>{{ formatDate(props.item.releaseDate) }}</span>
    </template>
    <template v-slot:item.actors="props">
      <v-row style="display: inline-block" class="pa-2">
        <p
          v-for="actor in props.item.actors"
          v-bind:key="actor.index"
          class="pa-0 ma-0"
        >{{ actor.name + " " + actor.surname }}</p>
      </v-row>
    </template>
    <template v-slot:item.averageRating="props">
      <v-rating
        small
        readonly
        v-model="props.item.averageRating"
        background-color="indigo lighten-3"
        color="indigo"
        large
      ></v-rating>
    </template>
  </v-data-table>
</template>

<script>
import moment, * as moments from "moment";
import Vue from "vue";
import VueMoment from "vue-moment";
Vue.use(VueMoment, {
  moments
});
export default {
  name: "DataTable",
  props: {
    show: {
      type: [Object]
    }
  },
  data() {
    return {
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
          text: "Description",
          value: "description"
        },
        {
          text: "Release Date",
          value: "releaseDate"
        },
        {
          text: "Actors",
          value: "actors"
        },
        {
          text: "Average Rating",
          value: "averageRating"
        }
      ]
    };
  },
  computed: {},
  methods: {
    formatDate(date) {
      return moment(date).format("YYYY-MM-DD");
    }
  }
};
</script>
