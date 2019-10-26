<template>
  <div class="main-container">
    <div class="columns search_columns">
      <div class="container">
        <div class="columns">
          <div class="column is-12">
            <p class="search-label">
              Search for restaurants and find your
              <b>meal reacommendations!</b>
            </p>
            <b-field>
              <b-input class="search-input" size="is-large" type="search" icon="magnify" />
            </b-field>
          </div>
        </div>
      </div>
    </div>
    <div class="container">
      <cards-list :cards="restaurants" label="Polecane" />
      <cards-list
        :cards="restaurants"
        v-for="category in categories.slice(0, 2)"
        :label="category.name"
      />
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import CardsList from '../components/CardsList'

export default {
  name: 'HomePage',
  components: { CardsList },
  computed: mapState(['categories', 'restaurants'])
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
  height: 175px;
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

.search-input {
  font-family: Rubik, sans-serif;
  margin: 5px 0;
}
</style>
