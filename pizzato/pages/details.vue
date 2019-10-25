<template>
  <div class="container">
    <div class="columns restaurant-container">
      <div class="column">
        <img :src="currentRestaurant.imageUrl" />
      </div>
      <div class="column is-two-thirds details-container">
        <p class="title">{{currentRestaurant.name}}</p>
        <p>{{currentRestaurant.city}}</p>
        <ul
          v-for="attribute in currentRestaurant.attributeList"
          v-bind:key="attribute.name"
          class="attr-list"
        >
          <li>{{attribute.name}}</li>
        </ul>
        <b-rate class="onBottom" @change="rateSuccess" custom-text="Oceń restaurację!"></b-rate>
      </div>
    </div>

    <!-- podobne -->
    <div class="similar-container">
        <p class="title">Podobne</p>
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
        </nav>
    </div>
  </div>
</template>

<script>
// import axios from '@nuxtjs/axios'

export default {
  props: ['restaurantId'],
  data () {
    return {
      currentRestaurant: {
        id: 0,
        imageUrl:
          'https://static.pepper.pl/live_pl/threads/thread_large/default/146522_1.jpg',
        name: 'McDonalds',
        city: 'Warszawa',
        attributeList: [
          { name: 'Fast-food' },
          { name: 'Hamburgery' },
          { name: 'Tanio' }
        ]
      },
      restaurants: [
        { name: 'KFC', imageUrl: 'http://media1.s-nbcnews.com/j/msnbc/Components/Photos/061113/061113_kfc_logo_vmed5p.grid-4x2.jpg' },
        { name: 'Kura', imageUrl: 'http://restauracjakura.pl/wp-content/uploads/2019/02/logo-restauracja-kura-biale.png' },
        { name: 'Bobby Burger', imageUrl: 'https://bobbyburger.pl/wp-content/uploads/2019/04/Bobby-Burger-logo.png' }
      ]
    }
  },
  create () {},
  methods: {
    rateSuccess () {
      this.$buefy.toast.open({
        message: 'Dziękujemy za wysłanie opinii!',
        type: 'is-success'
      })
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
