<template>
  <div class="main-container">
    <div class="columns search_columns">
      <div class="container">
        <div class="columns form-wrapper">
          <div class="column is-12">
            <p class="search-label">
              Search for restaurants and find your
              <b>meal recommendations!</b>
            </p>
            <div class="columns form-columns">
              <div class="location-wrapper">
                <b-dropdown class="city-dropdown" aria-role="list">
                  <button class="button city-button is-large" slot="trigger">
                    <b-icon icon="near-me"></b-icon>
                    <span>{{ this.searchCity || this.$route.query.city || "Location" }}</span>
                  </button>
                   <b-dropdown-item
                    v-for="city in cities"
                    :key="city.id"
                    @click="selectCity(city)"
                    aria-role="listitem"
                  >{{ city }}</b-dropdown-item>
                </b-dropdown>
              </div>
              <div class="search-wrapper">
                <b-field class="search-column column">
                  <b-input
                    v-model="searchInput"
                    @keyup.enter.native="onSearch"
                    class="search-input"
                    size="is-large"
                    type="search"
                    icon="magnify"
                  />
                </b-field>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container" v-if="!searchString">
      <client-only>
      <lazy-card-list
        :cards="rate.similar"
        v-for="rate in rated"
        :label="'Recommended based on ' + rate.current.name"
        :key="rate.current.name"
      />
      </client-only>
      <client-only>
      <lazy-card-list
        :cards="row.restaurants.filter(r => $route.query.city ? r.city === $route.query.city : true)"
        v-for="row in rows"
        :label="row.heading"
        :key="row.heading"
      />
</client-only>
    </div>
    <div class="container" v-else>
      <client-only>
      <cards-list
        :list="true"
        :cards="searchResults"
        :label="'Search results for query: ' + searchString"
        v-if="this.$route.query.q || searchResults.length > 0"
      />
      <p class="message" v-else>No results found 😭</p>
      </client-only>
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import LazyCardList from '../components/LazyCardList'
import CardsList from '../components/CardsList'

export default {
  name: 'HomePage',
  components: { CardsList, LazyCardList },
  computed: {
    ...mapState({
      cities: (state) => state.cities,
      rows: (state) => {
        return state.categories.map((category) => {
          return {
            heading: category.name,
            restaurants: state.restaurants.filter((restaurant) =>
              restaurant.tags.find((tag) => tag === category.name)
            )
          }
        })
      },
      restaurants: (state) => state.restaurants
    }),
    searchString() {
      return this.$route.query.q
    },
    searchResults() {
      const query = this.$route.query.q;
      const city = this.$route.query.city;
      if(!query) return [];
      return this.$store.state.restaurants.filter((restaurant) => {
        const nameMatch = restaurant.name
          .toLowerCase()
          .includes(query.toLowerCase())
        const tagMatch =
          restaurant.tags.filter((tag) =>
            tag.toLowerCase().includes(query.toLowerCase())
          ).length > 0;
        
        const inCity = this.$route.query.city ? restaurant.city === this.$route.query.city : true
        return inCity && (nameMatch || tagMatch)
      })
    }
  },
  methods: {
    onSearch() {
      this.$router.push({ query: { ...this.$route.query, q: this.searchInput, city: this.searchCity } })
    },
    selectCity(city) {
      this.searchCity = city;
      this.$router.push({ query: { ...this.$route.query, city } });
    },
  },
  beforeMount() {
    if (window.localStorage) {
      const rated = JSON.parse(localStorage.getItem('rated_restaurants')) || [];
      this.rated = rated;
    }
  },
  data() {
    return {
      searchCity: '',
      searchInput: '',
      rated: [],
    }
  }
}
</script>

<style scoped>
section {
  margin: 0;
  padding: 0;
}
.main-container {
  width: 100%;
  height: 100%;
}

.search_columns {
  padding-top: 10px;
  background: #e26241;
  width: 100%;
  height: 100%;
  margin: 0;
}

.search-label {
  font-family: Rubik, sans-serif;
  margin: 15px 0px 0px 0px;
  padding: 0px;
  font-size: 20px;
  color: #ffffff;
  font-weight: 400;
}

.form-wrapper {
  margin: 0 15px;
}

.search-input {
  font-family: Rubik, sans-serif;
  margin: 5px 0;
}

.search-column {
  padding-left: 0;
}

.message {
  font-family: Rubik, sans-serif;
  margin: 50px 0;
}

.city-dropdown {
  height: 100%;
  width: 100%;
  display: flex;
  align-items: center;
  font-family: Rubik, sans-serif;
}

.city-button {
  width: 150px;
}

.city-button > span {
  font-family: Rubik, sans-serif;
  font-size: 14px;
}

.search-wrapper {
  flex: 1;
}

@media (max-width: 768px) {
  .form-columns {
    margin: 15px 0 !important;
  }
}

@media (min-width: 769px) {
  .city-dropdown {
    margin: 0 10px;
  }
}
</style>
