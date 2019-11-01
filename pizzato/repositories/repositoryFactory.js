import CsvRepository from './csvRepository'
import CategoryRepository from './categoryRepository'
import RestaurantRepository from './restaurantRepository'
import CityRepository from './cityRepository'

const repositories = {
  csv: CsvRepository,
  category: CategoryRepository,
  restaurant: RestaurantRepository,
  city: CityRepository,
}

export const RepositoryFactory = {
  get: name => repositories[name]
}
