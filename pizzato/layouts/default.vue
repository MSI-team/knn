<template>
  <div>
    <nav
      class="navbar header has-shadow is-danger"
      role="navigation"
      aria-label="main navigation"
    >
      <div class="navbar-item center">
        <div class="full-width columns">
          <div class="container column is-8">
            <p class="logo-content">🍕Pizzato</p>
          </div>
        </div>
      </div>
    </nav>

    <section class="main-content columns">
      <div class="container column is-8">
        <nuxt />
      </div>
    </section>
  </div>
</template>

<script>
export default {
  data() {
    return {
      items: [
        {
          title: 'Home',
          icon: 'home',
          to: { name: 'index' }
        },
        {
          title: 'Inspire',
          icon: 'lightbulb',
          to: { name: 'inspire' }
        }
      ]
    }
  }
}
</script>

<style scoped>
.full-width {
  width: 100%;
}

.navbar-item.center {
  flex-grow: 1;
  flex-direction: column;
  justify-content: center;
}

.logo-content {
  font-family: Rubik, sans-serif;
  color: #fff;
  font-weight: bold;
}
</style>
