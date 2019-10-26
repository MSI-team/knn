<template>
  <div class="column">
    <div>
      <figure class="media">
        <p class="image">
          <img src="https://bulma.io/images/placeholders/128x128.png" />
        </p>
      </figure>
      <p class="title">xxxxxx</p>
      <b-tag>Indyjskie</b-tag>
      <b-tag>Fast-Food</b-tag>
      <b-tag>+3</b-tag>
    </div>
  </div>
</template>

<style>
.tag {
  background-color: #ffd369 !important;
}

.image {
  width: 100%;
  overflow: hidden;
  background-color: #dadada;
}

.title {
  font-family: Rubik, sans-serif;
  font-size: 16px;
  cursor: pointer;
  padding: 0;
  margin: 15px 0 !important;
}
.title:hover {
  color: #e26241;
}
</style>

<script>
export default {
  props: {
    title: {
      type: String,
      required: true
    },
    icon: {
      type: String,
      required: true
    }
  }
}
</script>
