using Microsoft.AspNetCore.Mvc;
using RestaurantDirectory.Models;
using RestaurantDirectory.Services;

namespace RestaurantDirectory.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Duplicate validation logic - SonarQube should flag this
        private bool ValidateRestaurantData(Restaurant restaurant)
        {
            if (string.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError("Name", "Restaurant name is required");
                return false;
            }
            if (string.IsNullOrEmpty(restaurant.Address))
            {
                ModelState.AddModelError("Address", "Restaurant address is required");
                return false;
            }
            if (restaurant.Rating < 1 || restaurant.Rating > 5)
            {
                ModelState.AddModelError("Rating", "Rating must be between 1 and 5");
                return false;
            }
            return true;
        }

        // Another duplicate validation method - identical logic
        private bool CheckRestaurantValidation(Restaurant restaurant)
        {
            if (string.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError("Name", "Restaurant name is required");
                return false;
            }
            if (string.IsNullOrEmpty(restaurant.Address))
            {
                ModelState.AddModelError("Address", "Restaurant address is required");
                return false;
            }
            if (restaurant.Rating < 1 || restaurant.Rating > 5)
            {
                ModelState.AddModelError("Rating", "Rating must be between 1 and 5");
                return false;
            }
            return true;
        }

        [HttpPost]
        public IActionResult Edit(Restaurant restaurant)
        {
            // Using duplicate validation method
            if (ValidateRestaurantData(restaurant) && ModelState.IsValid)
            {
                _restaurantData.Update(restaurant);
                return RedirectToAction(nameof(Details), new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurant restaurant)
        {
            // Using the other duplicate validation method
            if (CheckRestaurantValidation(restaurant) && ModelState.IsValid)
            {
                _restaurantData.Add(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // Duplicate error handling method
        private IActionResult HandleRestaurantNotFound(int id)
        {
            TempData["ErrorMessage"] = $"Restaurant with ID {id} was not found.";
            return RedirectToAction(nameof(Index));
        }

        // Another duplicate error handling method with same logic
        private IActionResult ProcessRestaurantNotFound(int id)
        {
            TempData["ErrorMessage"] = $"Restaurant with ID {id} was not found.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id, bool confirmed)
        {
            if (confirmed)
            {
                _restaurantData.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
