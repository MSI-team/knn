<template>
    <div>
      <figure class="media">
        <p class="image">
          <img :src="this.cover" />
        </p>
      </figure>
      <p class="title">{{title}}</p>
      <b-tag v-for="tag in reducedTags.list" :key="tag.id">{{ tag.tag }}</b-tag>
    </div>
</template>

<style>
.tag {
  font-family: Rubik, sans-serif;
  font-size: 13px;
  background-color: #ffd369 !important;
  color: #e26241 !important;
  margin-right: 4px;
  text-transform: uppercase;
  font-weight: bold;
  cursor: pointer;
}

.tag:hover {
  background-color: #940a37 !important;
  color: white !important;
  transition: .1s ease-in;
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
  font-weight: 600;
  padding: 0;
  margin: 15px 0 !important;
  white-space: nowrap;
  text-overflow: ellipsis;
  overflow: hidden;
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
    },
    tags: {
      type: Array,
    },
    image: {
      type: String,
    }
  },
  computed: {
      reducedTags () {
        return {
          list: [...this.tags.slice(0, 3).map((tag, id) => ({ id, tag })), ...(this.tags.length > 3 ? [{ id: 3, tag: `+${this.tags.length - 3}` }] : [])]
        }
      },
      cover () {
        if (this.image) {
          return this.image
        } else {
          return "https://bulma.io/images/placeholders/128x128.png"
        }
      }
  }
}
</script>
