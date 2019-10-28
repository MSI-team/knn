<template>
  <p class="tag">{{getDescription}}</p>
</template>

<script>
export default {
  name: 'DetailTag',
  props: {
    tag: {
      type: String
    }
  },
  methods: {
    getEmojiForTag(tag) {
      switch (tag) {
        case 'Bagels':
          return '🥯'
        case 'Beer':
          return '🍺'
        case 'Beverages':
          return '🥤'
        case 'Board Games':
          return '♟'
        case 'Breakfast':
          return '🥞'
        case 'Burger':
          return '🍔'
        case 'Cafe':
        case 'Coffee and Tea':
        case 'Tea':
          return '☕'
        case 'Caribbean':
            return '🏝️'
        case 'Cash':
          return '💵'
        case 'Credit Card':
          return '💳'
        case 'Dance Floor':
          return '💃'
        case 'Delivery':
          return '🚚'
        case 'Desserts':
        case 'Desserts and Bakes':
          return '🍰'
        case 'Dinner':
          return '🍽️'
        case 'DisabledFriendly':
          return '♿'
        case 'Donuts':
          return '🍩'
        case 'Free Parking':
        case 'Street Parking':
          return '🅿️'
        case 'French':
          return '🥖'
        case 'Grill':
          return '🍖'
        case 'Healthy Food':
          return '🥗'
        case 'Ice Cream':
          return '🍨'
        case 'Indian':
          return '🍛'
        case 'Indoor Seating':
          return '💺'
        case 'International':
          return '🌐'
        case 'Italian':
          return '🍝'
        case 'International':
          return '🌐'
        case 'Japanese':
          return '⛩'
        case 'Jewish':
          return '🕎'
        case 'Kebab':
            return '🥙'
        case 'Lunch':
        case 'Lunch Menu':
            return '🥪'
        case 'Mexican':
            return '🌮'
        case 'Nightlife':
        return '🌃'
        case 'Outdoor Seating':
            return '🪑'
        case 'Pet friendly': 
            return '🐾'
        case 'Pizza':
            return '🍕'
        case 'Seafood':
            return '🦐'
        case 'Serves Alcohol':
        case 'Wine':
            return '🍷'
        case 'Smoking Area':
            return '🚬'
        case 'Snacks':
            return '🍿'
        case 'Sports Bar':
            return '⚽'
        case 'Steak':
            return '🥩'
        case 'Sushi':
            return '🍣'
        case 'Takeaway Available':
            return '🥡'
        case 'Tex-Mex':
            return '🌯'
        case 'Vegan Options':
        case 'Vegetarian Friendly':
            return '🌿'
        case 'Wifi':
            return '📡'
        default:
          return ''
      }
    }
  },
  computed: {
    getDescription() {
      return `${this.getEmojiForTag(this.tag)} ${this.tag}`
    }
  }
}
</script>

<style scoped>
.tag {
  font-family: Rubik, sans-serif;
  font-size: 1rem;
  color: #e26241 !important;
  margin-right: 4px;
  text-transform: uppercase;
  font-weight: bold;
}

/* .tag:hover {
  background-color: #940a37 !important;
  color: white !important;
  transition: .1s ease-in;
} */
</style>