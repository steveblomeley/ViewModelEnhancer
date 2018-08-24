using System;
using System.Web.Mvc;
using ViewModelEnhancer.Augmenters;
using ViewModelEnhancer.Models;

namespace ViewModelEnhancer.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IMasterAugmenter _viewModelAugmenter;

        public LocationsController(IMasterAugmenter viewModelAugmenter)
        {
            _viewModelAugmenter = viewModelAugmenter;
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
            _viewModelAugmenter.TryAugment(model);

            return View(model);
        }
    }
}