using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModelEnhancer.Augmenters;
using ViewModelEnhancer.Models;

namespace ViewModelEnhancer.Controllers
{
    public class NotAController
    {
        private readonly IAugmenter _viewModelAugmenter;
        private readonly string _defaultForecast;

        public NotAController(IAugmenter viewModelAugmenter, string defaultForecast = "")
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
                    .Select(i => new HourlyForecast
                    {
                        Time = new TimeSpan(i, 0, 0),
                        Weather = _defaultForecast
                    })
            };
        }

        public object JustGetTheModel()
        {
            var model = FakeReadFromRepository();
            _viewModelAugmenter.TryAugment(model);
            return model;
        }
    }
}
