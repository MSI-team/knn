import axios from 'axios'
import config from '../nuxt.config.js'

const Repository = axios.create({
  baseURL: config.backendUrl,
})

export default {
  async getCategories() {
    const { data } = await Repository.get()
    if (data) {
      return data
    } else {
      return []
    }
  }
}
