import axios from 'axios'

const baseDomain = 'http://localhost:5000'
const baseURL = `${baseDomain}/api/restaurants/import`

const Repository = axios.create({
  baseURL,
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
