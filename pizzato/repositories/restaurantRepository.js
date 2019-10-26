import axios from 'axios'

const baseDomain = 'http://localhost:5000'
const baseURL = `${baseDomain}/api`

const Repository = axios.create({
  baseURL
})

export default {
  async getRestaurantById (id) {
    try {
      const { data } = await Repository.get(`/Restaurants/${id}`)     
      if (data) {
        return data
      } else {
        return null
      }
    } catch (error) {
      console.error(
        `There was an error while requesting restaurant of id ${id}`
      )
    }
  },
  async getRestaurantsByCategory (category) {
    try {
      const { data } = await Repository.get(`/Tags/${category}`)
      if (data) {
        return data
      } else {
        return []
      }
    } catch (error) {
      console.error(
        `There was an error while requesting restaurants list of category ${category}`
      )
    }
  },
  async getAll () {
    const { data } = await Repository.get(`/Restaurants`)
    if (data) {
      return data
    } else {
      return []
    }
  },
  async getRecomendationsForRestaurant (id, city, recommendationsCount) {
    const { data } = await Repository.get(`/Recommend/${id}/${city}/${recommendationsCount}`)
    if (data) {
      return data
    } else {
      return []
    }
  }
}
