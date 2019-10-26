<template>
  <div class="container">
    <div class="columns restaurant-container">
      <div class="column">
        <img :src="getPhoto" />
      </div>
      <div class="column is-two-thirds details-container">
        <p class="title">{{currentRestaurant.name}}</p>
        <p class="subtitle">{{currentRestaurant.city}}</p>
        <ul class="attr-list">
          <li v-for="tag in currentRestaurant.tags">
            {{tag}}
          </li>
        </ul>
        <b-rate class="onBottom" @change="rateSuccess" custom-text="Oceń restaurację!"></b-rate>
      </div>
    </div>

    <!-- podobne -->
    <div class="similar-container">
      <!-- <p class="title">Podobne</p>
      <nav class="level">
        <div
          v-for="restaurant in restaurants"
          v-bind:key="restaurant.id"
          class="level-item has-text-centered"
        >
          <a href="#">
            <img :src="restaurant.imageUrl" width="64" />
            <p>{{restaurant.name}}</p>
          </a>
        </div>
      </nav> -->
      <cards-list :cards="restaurants" :label="'Polecane'" />
    </div>
  </div>
</template>

<script>
import CardsList from '../../components/CardsList'
import RestaurantRepository from '../../repositories/restaurantRepository'

export default {
  name: "Details",
  components: { CardsList },
  data () {
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
  async beforeMount () {
    const loading = this.$buefy.loading.open({
      container: null
    })
    await this.initData();
    loading.close()
  },
  methods: {
    tostify (toastMessage, success) {
      this.$buefy.toast.open({
        message: toastMessage,
        type: success ? 'is-success' : 'is-warning'
      })
    },
    rateSuccess () {
      this.tostify('Dziękujemy za wysłanie opinii!', true)
    },
    async initData () {
        await this.getRestaurantData()
        await this.getSimilarRestaurants()
    },
    getRestaurantData () {
      return RestaurantRepository.getRestaurantById(this.$route.params.id)
        .then((response) => {
          console.log(response)
          // console.log(this.$set)
          // this.$set(this.currentRestaurant, response.id, response)
          this.currentRestaurant.id = response.id;
          this.currentRestaurant.name = response.name;
          this.currentRestaurant.city = response.city;
          this.currentRestaurant.photoUrl = response.photoUrl;

          console.log(response.tags)
          this.currentRestaurant.tags = [...response.tags];
        })
        .catch((error) => {
          console.log(error)
          this.tostify('Błąd! Nie można pobrać danych restauracji!')
        })
    },
    getSimilarRestaurants () {
      return RestaurantRepository.getRecomendationsForRestaurant(
        this.currentRestaurant.id, this.currentRestaurant.city, 4
      ).then((response) => {
        console.log(response)
        this.restaurants = response;
      })
      .catch((error) => {
        console.log(error)
        this.tostify('Błąd! Nie można pobrać listy podobnych restauracji!')
      })
    }
  },
  computed: {
    getPhoto () {
      const baseImageUrl = "https://bulma.io/images/placeholders/128x128.png"

      if (this.currentRestaurant) {
        return this.currentRestaurant.photoUrl
      }

      return baseImageUrl;
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
</style>
