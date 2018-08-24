using System;
using System.Web.Mvc;
using ViewModelEnhancer.Augmenters;
using ViewModelEnhancer.Models;

namespace ViewModelEnhancer.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IAugmenter _weatherAugmenter;

        public LocationsController(IAugmenter weatherAugmenter)
        {
            _weatherAugmenter = weatherAugmenter;
        }

        private Location RandomLocation()
        {
            return new Location()
            {
                Id = 123,
                Name = "Manchester",
                Description = "Home of the industrial revolution, and shocking weather.",
                Date = DateTime.Now
            };
        }

        public ViewResult GetLocation()
        {
            var model = RandomLocation();
            _weatherAugmenter.TryAugment(model);

            return View(model);
        }
    }
}