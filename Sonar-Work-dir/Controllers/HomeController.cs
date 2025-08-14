using Microsoft.AspNetCore.Mvc;
using RestaurantDirectory.Models;
using RestaurantDirectory.Services;
using System.Diagnostics;

namespace RestaurantDirectory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestaurantData _restaurantData;

        public HomeController(ILogger<HomeController> logger, IRestaurantData restaurantData)
        {
            _logger = logger;
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantData.GetAll().Take(3),
                TotalCount = _restaurantData.GetCount()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public int TotalCount { get; set; }
    }
}
