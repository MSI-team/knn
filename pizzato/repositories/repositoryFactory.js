import CsvRepository from './csvRepository'
import CategoryRepository from './categoryRepository'
import RestaurantRepository from './restaurantRepository'

const repositories = {
  csv: CsvRepository,
  category: CategoryRepository,
  restaurant: RestaurantRepository
}

export const RepositoryFactory = {
  get: name => repositories[name]
}
