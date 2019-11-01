import { RepositoryFactory } from '../repositories/repositoryFactory'

export const state = () => ({
  categories: [],
  restaurants: [],
  cities: []
})

export const mutations = {
  setCategories(state, categories = []) {
    state.categories = categories.map((name, id) => ({ id, name }))
  },
  setRestaurants(state, restaurants = []) {
    state.restaurants = [...state.restaurants, ...restaurants]
  },
  setCities(state, cities = []) {
    state.cities = cities;
  }
}
export const actions = {
  async nuxtServerInit({ commit }) {
    const cities = await RepositoryFactory.get('city').getCities()
    commit('setCities', cities)
    const categories = await RepositoryFactory.get('category').getCategories()
    commit('setCategories', categories)
    const restaurants = await RepositoryFactory.get('restaurant').getAll()
    commit('setRestaurants', restaurants)
  }
}
