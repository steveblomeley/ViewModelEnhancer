using System;
using System.Linq;
using System.Web.Mvc;
using ViewModelEnhancer.Models;
using ViewModelEnhancer.Services.Augmenters;

namespace ViewModelEnhancer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAugmenter _viewModelAugmenter;
        private readonly string _defaultForecast;

        public HomeController(IAugmenter viewModelAugmenter, string defaultForecast = "")
        {
            _viewModelAugmenter = viewModelAugmenter;
            _defaultForecast = defaultForecast;
        }

        private LocationDay RandomLocationDay()
        {
            return new LocationDay
            {
                Id = 124,
                Name = "Salford",
                Date = DateTime.Now,
                HourlyForecasts = Enumerable
                    .Range(0, 24)
                    .Select(i => new HourlyForecast{
                        Time = new TimeSpan(i, 0, 0),
                        Weather = _defaultForecast
                    })
            };
        }

        public ViewResult Index()
        {
            var model = RandomLocationDay();
            _viewModelAugmenter.TryAugment(model);
            return View(model);
        } 
    }
}