using System;
using System.Linq;
using NUnit.Framework;
using ViewModelEnhancer.Augmenters;
using ViewModelEnhancer.Controllers;
using ViewModelEnhancer.Models;

namespace ViewModelEnhancer.Services.Tests.Augmenters
{
    public class HourlyForecastAugmenterTests
    {
        private LocationWithHourlyForecasts _model;

        [SetUp]
        public void Setup()
        {
            _model = new LocationWithHourlyForecasts
            {
                HourlyForecasts = new[]
                {
                    new HourlyForecast{ Time = new TimeSpan(12, 0, 0), Weather = string.Empty}
                }
            };
        }

        [Test]
        public void AugmentMethod_AddsForecast_ToEachHour()
        {
            var sut = new HourlyForecastAugmenter();

            Assert.That(_model.HourlyForecasts.ToArray()[0].Weather, Is.EqualTo(string.Empty));

            sut.TryAugment(_model);

            Assert.That(_model.HourlyForecasts.ToArray()[0].Weather, Is.Not.EqualTo(string.Empty));
        }

        [Test]
        public void AugmentMethod_StillWorksAsExpected_WhenInvokedVia_TheControllerAction()
        {
            const string defaultForecast = "-- no forecast --";
            var sut = new HourlyForecastAugmenter();
            var controller = new HomeController(sut, defaultForecast);

            var result = controller.Index().Model;

            Assert.That(result, Is.InstanceOf<LocationWithHourlyForecasts>());
            var model = (LocationWithHourlyForecasts) result;

            Assert.That(model.HourlyForecasts.ToArray()[0].Weather, Is.Not.EqualTo(defaultForecast));
        }
    }
}