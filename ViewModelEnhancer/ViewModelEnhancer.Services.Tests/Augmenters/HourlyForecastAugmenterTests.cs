using System;
using System.Linq;
using NUnit.Framework;
using ViewModelEnhancer.Controllers;
using ViewModelEnhancer.Models;
using ViewModelEnhancer.Services.Augmenters;

namespace ViewModelEnhancer.Services.Tests.Augmenters
{
    public class HourlyForecastAugmenterTests
    {
        private LocationDay _model;

        [SetUp]
        public void Setup()
        {
            _model = new LocationDay
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
            var sut = new HourlyForecastAugmenter<HourlyForecast>();

            Assert.That(_model.HourlyForecasts.ToArray()[0].Weather, Is.EqualTo(string.Empty));

            sut.TryAugment(_model);

            Assert.That(_model.HourlyForecasts.ToArray()[0].Weather, Is.Not.EqualTo(string.Empty));
        }

        [Test]
        public void AugmentMethod_StillWorksAsExpected_WhenInvokedVia_TheMasterAugmenter()
        {
            var sut = new HourlyForecastAugmenter<HourlyForecast>();
            var masterAugmenter = new MasterAugmenter(new[] { sut });

            Assert.That(_model.HourlyForecasts.ToArray()[0].Weather, Is.EqualTo(string.Empty));

            masterAugmenter.TryAugment(_model);

            Assert.That(_model.HourlyForecasts.ToArray()[0].Weather, Is.Not.EqualTo(string.Empty));
        }

        [Test]
        public void AugmentMethod_StillWorksAsExpected_WhenInvokedVia_TheMasterAugmenter_AndControllerAction()
        {
            var sut = new HourlyForecastAugmenter<HourlyForecast>();
            var masterAugmenter = new MasterAugmenter(new[] { sut });
            var controller = new HomeController(masterAugmenter);

            var result = controller.Index().Model;

            Assert.That(result, Is.InstanceOf<LocationDay>());
            var model = (LocationDay) result;

            Assert.That(model.HourlyForecasts.ToArray()[0].Weather, Is.Not.EqualTo(string.Empty));
        }
    }
}
