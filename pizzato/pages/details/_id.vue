<template>
  <div class="container">
    <div class="columns restaurant-container">
      <div class="column">
        <img :src="getPhoto" class="main-img" />
      </div>
      <div class="column is-two-thirds details-container">
        <p class="title">{{currentRestaurant.name}}</p>
        <p class="subtitle">{{currentRestaurant.city}}</p>
        <div class="columns">
          <div class="column">
            <ul class="attr-list">
              <li v-for="tag in getFirstTagColumn">
                <detail-tag :tag="tag" />
              </li>
            </ul>
          </div>
          <div class="column">
            <ul class="attr-list">
              <li v-for="tag in getLastTagColumn">
                <detail-tag :tag="tag" />
              </li>
            </ul>
          </div>
        </div>
        <b-rate class="onBottom" @change="rateSuccess" custom-text="Oceń restaurację!"></b-rate>
      </div>
    </div>
    <div class="similar-container">
      <cards-list :cards="restaurants" :label="'Polecane'" />
    </div>
  </div>
</template>

<script>
import DetailTag from '../../components/DetailTag'
import CardsList from '../../components/CardsList'
import RestaurantRepository from '../../repositories/restaurantRepository'

export default {
  name: 'Details',
  components: { CardsList, DetailTag },
  data() {
    return {
      currentRestaurant: {
        id: 0,
        photoUrl: '',
        name: '',
        city: '',
        tags: []
      },
      restaurants: []
    }
  },
  async beforeMount() {
    const loading = this.$buefy.loading.open({
      container: null
    })
    await this.initData()
    loading.close()
  },
  methods: {
    tostify(toastMessage, success) {
      this.$buefy.toast.open({
        message: toastMessage,
        type: success ? 'is-success' : 'is-warning'
      })
    },
    rateSuccess() {
      if (window.localStorage) {
        const rated = JSON.parse(localStorage.getItem("rated_restaurants")) || [];
        const newRated = [{ current: this.currentRestaurant, similar: this.restaurants }, ...rated];
        localStorage.setItem("rated_restaurants", JSON.stringify(newRated));
      }
      this.tostify('Dziękujemy za wysłanie opinii!', true)
    },
    async initData() {
      await this.getRestaurantData()
      await this.getSimilarRestaurants()
    },
    getRestaurantData() {
      return RestaurantRepository.getRestaurantById(this.$route.params.id)
        .then((response) => {
          this.currentRestaurant.id = response.id
          this.currentRestaurant.name = response.name
          this.currentRestaurant.city = response.city
          this.currentRestaurant.photoUrl = response.photoUrl

          console.log(response.tags)
          this.currentRestaurant.tags = [...response.tags]
        })
        .catch((error) => {
          console.log(error)
          this.tostify('Błąd! Nie można pobrać danych restauracji!')
        })
    },
    getSimilarRestaurants() {
      return RestaurantRepository.getRecomendationsForRestaurant(
        this.currentRestaurant.id,
        this.currentRestaurant.city,
        4
      )
        .then((response) => {
          console.log(response)
          this.restaurants = response
        })
        .catch((error) => {
          console.log(error)
          this.tostify('Błąd! Nie można pobrać listy podobnych restauracji!')
        })
    }
  },
  computed: {
    getPhoto() {
      const baseImageUrl = 'https://bulma.io/images/placeholders/128x128.png'

      if (this.currentRestaurant) {
        return this.currentRestaurant.photoUrl
      }

      return baseImageUrl
    },
    getFirstTagColumn() {
      return this.currentRestaurant.tags.slice(0, 10)
    },
    getLastTagColumn() {
      const length = this.currentRestaurant.tags.length
      return length - 10 < 0
        ? []
        : this.currentRestaurant.tags.slice(10, length)
    }
  }
}
</script>

<style>
.restaurant-container {
  margin-top: 3em;
}

.details-container {
  position: relative;
}

.similar-container {
  margin-top: 3em;
}

.onBottom {
  position: absolute;
  bottom: 0;
}

@media (min-width: 960px) {
  .main-img {
    min-width: 100%;
  }
}
</style>
