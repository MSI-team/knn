import axios from 'axios'
import config from '../nuxt.config.js'

const Repository = axios.create({
  baseURL: config.backendUrl,
  headers: { 'Content-Type': `multipart/form-data` }
})

export default {
  uploadCsv (file) {
    if (!file) {
      return
    }
    const formData = new FormData()
    formData.append('file', file)
    return Repository.post('', formData)
  }
}
