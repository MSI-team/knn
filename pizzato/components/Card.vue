<template>
    <div>
      <figure class="media">
        <p class="image">
          <img :src="this.cover" />
        </p>
      </figure>
      <a :href="detailsLink"><p class="title">{{title}}</p></a>
      <span v-for="tag in reducedTags.list" :key="tag.id">
          <a :href="tagLink(tag)">
            <b-tag>{{tag.tag}}</b-tag>
          </a>
      </span>
    </div>
</template>

<style scoped>
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
  width: 128px;
  height: auto;
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
    id: {
      type: Number,
    },
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
  methods: {
    tagLink (tag) {
      return tag.tag.match(/[a-zA-Z\s]+/) ? `/?q=${tag.tag}` : '#'
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
      },
      detailsLink () { 
        return `/details/${this.id}`
      }
  }
}
</script>
