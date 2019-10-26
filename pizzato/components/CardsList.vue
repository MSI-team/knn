<template>
  <div class="cards--list">
    <h2 class="heading">{{ label }}</h2>
    <div class="columns">
      <div
        class="column is-4"
        v-for="card in cards"
        :key="card.id"
        v-bind="{card}"
      >
        <card :title="card.name" :image="card.photoUrl" :tags="card.tags" />
      </div>
    </div>
  </div>
</template>

<style>
.heading {
  font-family: Rubik, sans-serif;
  font-size: 24px;
  margin: 25px 0;
  padding-bottom: 20px;
  border-bottom: 1px solid #dadada;
}
</style>

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
  }
}
</script>
