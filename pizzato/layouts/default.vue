<template>
  <div class="wrapper">
    <nav class="navbar header is-primary" role="navigation" aria-label="main navigation">
      <div class="navbar-item center">
        <div
          class="container navbar-container columns"
          v-bind:class="{ 'border-nav': $route.path == '/' }"
        >
          <div class="column is-4">
            <nuxt-link to="/">
              <p class="logo-content">🍕Pizzato</p>
            </nuxt-link>
          </div>
          <div class="dropdown-wrapper column is-8">
            <b-field class="file">
              <b-upload v-model="file">
                <a class="button nav-button">Import Database</a>
              </b-upload>
            </b-field>
            <b-dropdown aria-role="list">
              <p slot="trigger" class="dropdown-trigger" role="button">
                Browse Categories
                <b-icon icon="menu-down" size="is-small" />
              </p>
              <b-dropdown-item
                v-for="category in categories"
                :key="category.id"
                @click="selectCategory(category.name)"
                aria-role="listitem"
              >{{ category.name }}</b-dropdown-item>
              <b-dropdown-item v-if="categories.length === 0" aria-role="listitem">Import CSV</b-dropdown-item>
            </b-dropdown>
          </div>
        </div>
      </div>
    </nav>
    <section class="main-content columns">
      <nuxt />
    </section>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import { RepositoryFactory } from '../repositories/repositoryFactory'

export default {
  data() {
    return {
      file: null,
      mainPage: true
    }
  },
  computed: mapState(['categories']),
  watch: {
    async file(value) {
      await RepositoryFactory.get('csv').uploadCsv(value)
      window.location = '/'
    }
  },
  methods: {
    selectCategory(value) {
      this.$router.push({ path: '/', query: { q: value } })
    }
  }
}
</script>

<style lang="scss" scoped>
$widescreen: 60px;
.wrapper {
  height: 100%;
  min-height: 100vh;
  background: #f3f3f3;
}
.navbar-container {
  width: 100%;
  margin: 0;
}

.navbar.header {
  background: #e26241;
  margin: 0;
}

.navbar-item.center {
  flex-grow: 1;
  flex-direction: column;
  justify-content: center;
  padding-bottom: 0;
}

.border-nav {
  border-bottom: 1px solid #fff;
}

.nav-button {
  font-family: Rubik, sans-serif;
  background: #ffd369;
  border: none;
  color: #e26241;
  font-weight: 600;
  cursor: pointer;
  align-self: center;
  margin-right: 15px;
}

.nav-button:hover {
  background-color: #940a37 !important;
  color: white;
  transition: 0.1s ease-in;
}

.logo-content {
  font-family: Rubik, sans-serif;
  color: #fff;
  font-weight: bold;
  font-size: 32px;
}

.main-content {
  margin: 0;
  padding: 0;
}

.dropdown-wrapper {
  display: flex;
  justify-content: flex-start;
}

@media (min-width: 769px) {
  .dropdown-wrapper {
    flex-direction: row-reverse;
  }

  .nav-button {
    margin-left: 15px;
  }
}

.dropdown-trigger {
  font-family: Rubik, sans-serif;
  text-decoration: none;
  font-size: 14px;
  color: #fff;
  font-weight: 600;
  text-transform: uppercase;
  cursor: pointer;
  margin: 15px 0;
}

.dropdown-trigger:hover {
  color: #ffd369;
}

.file {
  margin-bottom: 0;
}
</style>
