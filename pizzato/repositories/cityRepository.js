import axios from 'axios'
import config from '../nuxt.config.js'

const Repository = axios.create({
  baseURL: config.backendUrl
})

export default {
  async getCities() {
    const { data } = await Repository.get('/Cities')
    if (data) {
      return data
    } else {
      return []
    }
  }
}
