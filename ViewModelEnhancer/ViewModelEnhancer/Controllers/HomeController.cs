using System;
using System.Linq;
using System.Web.Mvc;
using ViewModelEnhancer.Augmenters;
using ViewModelEnhancer.Models;

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

        private LocationWithHourlyForecasts FakeReadFromRepository()
        {
            return new LocationWithHourlyForecasts
            {
                Name = "Salford",
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
            var model = FakeReadFromRepository();
            _viewModelAugmenter.TryAugment(model);
            return View(model);
        }

        public object JustGetTheModel()
        {
            var model = FakeReadFromRepository();
            _viewModelAugmenter.TryAugment(model);
            return model;
        }
    }
}