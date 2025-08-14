using RestaurantDirectory.Models;

namespace RestaurantDirectory.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Bella Italia", Address = "123 Main St", Phone = "555-0123", Cuisine = "Italian", Rating = 4, Description = "Authentic Italian cuisine in a cozy atmosphere" },
                new Restaurant { Id = 2, Name = "Dragon Palace", Address = "456 Oak Ave", Phone = "555-0456", Cuisine = "Chinese", Rating = 5, Description = "Traditional Chinese dishes with modern presentation" },
                new Restaurant { Id = 3, Name = "Taco Loco", Address = "789 Pine Rd", Phone = "555-0789", Cuisine = "Mexican", Rating = 3, Description = "Fresh Mexican food with bold flavors" }
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = _restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }
            return restaurant!;
        }

        public Restaurant? Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        // Duplicate method with same logic - SonarQube should flag this
        public Restaurant? FindRestaurantById(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        // Another duplicate method
        public Restaurant? LocateRestaurant(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public int GetCount()
        {
            return _restaurants.Count;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.FirstOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Address = updatedRestaurant.Address;
                restaurant.Phone = updatedRestaurant.Phone;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
                restaurant.Rating = updatedRestaurant.Rating;
                restaurant.Description = updatedRestaurant.Description;
            }
            return restaurant!;
        }
    }
}
