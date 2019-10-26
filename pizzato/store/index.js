import { RepositoryFactory } from '../repositories/repositoryFactory'

export const state = () => ({
  categories: [],
  restaurants: []
})

export const mutations = {
  setCategories (state, categories = []) {
    state.categories = categories.map((name, id) => ({ id, name }))
  },
  setRestaurants (state, restaurants = []) {
    console.log(restaurants)
    state.restaurants = [
      ...state.restaurants,
      ...restaurants
    ]
  }
}
export const actions = {
  async nuxtServerInit ({ commit }) {
    const categories = await RepositoryFactory.get('category').getCategories()
    commit('setCategories', categories)
    const restaurants = await RepositoryFactory.get('restaurant').getAll()
    commit('setRestaurants', restaurants);
  }
}
