using System;
using System.Linq;
using NUnit.Framework;
using ViewModelEnhancer.Models;
using ViewModelEnhancer.Services.Augmenters;

namespace ViewModelEnhancer.Services.Tests.Augmenters
{
    public class HourlyForecastAugmenterTests
    {
        [Test]
        public void AugmentMethod_AddsForecast_ToEachHour()
        {
            var model = new LocationDay
            {
                HourlyForecasts = new []
                {
                    new HourlyForecast{ Time = new TimeSpan(12, 0, 0), Weather = string.Empty}
                }
            };

            var sut = new HourlyForecastAugmenter<HourlyForecast>();

            Assert.That(model.HourlyForecasts.ToArray()[0].Weather, Is.EqualTo(string.Empty));

            sut.TryAugment(model);

            Assert.That(model.HourlyForecasts.ToArray()[0].Weather, Is.Not.EqualTo(string.Empty));
        }
    }
}
