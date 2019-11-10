<template>
  <div class="cards-list">
    <h2 class="heading">{{ label }}</h2>
    
    <!-- Normal View -->
    <div class="columns" v-if="cardList.length < 5">
      <div
        class="column is-3"
        v-for="card in cardList"
        :key="card.id"
        v-bind="{card}"
      >
        <card :id="card.id" :title="card.name" :image="card.photoUrl" :tags="card.tags" />
      </div>
    </div>

    <!-- Carousel -->
    <div class="columns" v-else>
      <div class="column carousel-control">
        <div class='carousel-control-left' @click="prev()"></div>
      </div>
      <div class="column is-fourth-fifth">
        <div class='carousel-view'>
          <transition-group
            class='carousel'
            tag="div">
            <div class="slide"
              v-for="card in cardArray"
              :key="card.id"
              v-bind="{card}">
                <card :id="card.id" :title="card.name" :image="card.photoUrl" :tags="card.tags" />
            </div>
          </transition-group>
        </div>
      </div>
      <div class="column carousel-control">
        <div class='carousel-control-right' @click="next()"></div>
      </div>  
    </div>

  </div>
</template>

<script>
import Card from './Card'

export default {
  name: 'CardsList',
  components: { Card },
  props: {
    label: {
      type: String,
      required: true
    },
    cards: {
      type: Array,
      required: true
    }
  },
  methods: {
    prev () {
      const last = this.cardArray.pop()
      this.cardArray = [last].concat(this.cardArray)
    },
    next () {
      const first = this.cardArray.shift()
      this.cardArray = this.cardArray.concat(first)
    }
  },
  computed: {
    cardArray: {
      get: function() {
        return this.cardList
      },
      set: function(cards) {
        this.cardList = [...cards]
      }
    }
  },
  data() {
    return {
      cardList: []
    }
  },
  watch: {
    cards: {
      // the callback will be called immediately after the start of the observation
      immediate: true, 
      handler (val, oldVal) {
        if ((val && val.length) || (val.restaurants && val.restaurants.length)) {
          this.cardArray = val.length ? val : val.restaurants
        }
      }
    }
  }

}
</script>

<style scoped lang="scss">
.heading {
  font-family: Rubik, sans-serif;
  font-size: 24px;
  margin: 25px 0;
  padding-bottom: 20px;
  border-bottom: 1px solid #dadada;
}

.cards-list {
  margin: 0 15px;
}

.carousel-view {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.carousel {
  display: flex;
  justify-content: center;
  align-items: baseline;
  overflow: hidden;

  width: 50em;
  min-height: 15em;
}
.slide {
  flex: 0 0.1 20em;
  margin-left: 0.5em;
  margin-right: 0.5em;

  display: flex;
  justify-content: center;
  align-items: stretch;

  transition: transform 0.3s ease-in-out;
}
.slide:first-of-type {
  opacity: 0;
}
.slide:last-of-type {
  opacity: 0;
}

.carousel-control {
  display: flex;
  align-items: center;
}

.carousel-control-left,
.carousel-control-right {
  display: inline-block;
  width: 15px;
  height: 15px;
  padding: 10px;
  box-sizing: border-box;
  border-top: 2px solid #42b883;
  border-right: 2px solid #42b883;
  cursor: pointer;
  margin: 0 20px;
  transition: transform 150ms linear;
  &[disabled] {
    opacity: 0.2;
    border-color: black;
  }
}

.carousel-control-left {
  transform: rotate(-135deg);
  &:active {
    transform: rotate(-135deg) scale(0.9);
  }
}

.carousel-control-right {
  transform: rotate(45deg);
  &:active {
    transform: rotate(45deg) scale(0.9);
  }
}
</style>
