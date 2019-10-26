import axios from 'axios'

const baseDomain = 'http://localhost:5000'
const baseURL = `${baseDomain}/api/Tags`

const Repository = axios.create({
  baseURL
})

export default {
  async getCategories () {
    const { data } = await Repository.get()
    if (data) {
      return data
    } else {
      return []
    }
  }
}
