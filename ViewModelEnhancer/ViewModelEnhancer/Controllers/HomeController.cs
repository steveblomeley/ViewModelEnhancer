using System;
using System.Linq;
using System.Web.Mvc;
using ViewModelEnhancer.Models;
using ViewModelEnhancer.Services.Augmenters;

namespace ViewModelEnhancer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMasterAugmenter _viewModelAugmenter;

        public HomeController(IMasterAugmenter viewModelAugmenter)
        {
            _viewModelAugmenter = viewModelAugmenter;
        }

        private static Location RandomLocation()
        {
            return new Location
            {
                Id = 123,
                Name = "Manchester",
                Date = DateTime.Now
            };
        }

        private static LocationDay RandomLocationDay()
        {
            return new LocationDay
            {
                Id = 124,
                Name = "Salford",
                Date = DateTime.Now,
                HourlyForecasts = Enumerable
                    .Range(0, 24)
                    .Select(i => new HourlyForecast{
                        Hour = new TimeSpan(i, 0, 0),
                        Weather = string.Empty
                    })
            };
        }

        public ViewResult GetLocation()
        {
            var model = RandomLocation();
            _viewModelAugmenter.TryAugment(model);

            return View(model);
        }

        public ViewResult Index()
        {
            var model = RandomLocationDay();
            _viewModelAugmenter.TryAugment(model);
            return View(model);
        } 
    }
}