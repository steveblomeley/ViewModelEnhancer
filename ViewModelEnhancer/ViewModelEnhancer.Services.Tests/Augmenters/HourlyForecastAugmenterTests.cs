using System;
using System.Linq;
using NUnit.Framework;

namespace ViewModelEnhancer.Services.Tests.Augmenters
{
    public class HourlyForecastAugmenterTests
    {
        [Test]
        public void AugmentMethod_AddsForecast_ToEachHour()
        {
            const string actualForecast = "calm and cloudy";
            var sut = new ForecastService(actualForecast);

            var model = new LocationWithHourlyForecasts
            {
                HourlyForecasts = Enumerable
                    .Range(0, 1)
                    .Select(i =>
                    {
                        Console.WriteLine($"Inside the enumeration, with i={i}");
                        return new HourlyForecast
                        {
                            Weather = string.Empty
                        };
                    }).ToList()
            };

            Assert.That(model.HourlyForecasts.First().Weather, Is.EqualTo(string.Empty));

            sut.AddHourlyForecastToModel(model);

            Assert.That(model.HourlyForecasts.First().Weather, Is.Not.EqualTo(string.Empty));
            Assert.That(model.HourlyForecasts.First().Weather, Is.EqualTo(actualForecast));
        }

        [Test]
        public void AugmentMethod_StillWorksAsExpected_WhenInvokedVia_ANonControllerMethod_ThatSimplyReturns_TheModel()
        {
            const string actualForecast = "hot and sunny";
            var service = new ForecastService(actualForecast);
            var notAcontroller = new NotAController(service);

            var model = notAcontroller.JustGetTheModel();

            Assert.That(model.HourlyForecasts.First().Weather, Is.Not.EqualTo(string.Empty));
            Assert.That(model.HourlyForecasts.First().Weather, Is.EqualTo(actualForecast));
        }

        [Test]
        public void Test()
        {
            const string actualForecast = "wet and windy";
            var service = new ForecastService_WithCopyToList(actualForecast);
            var notAcontroller = new NotAController(service);

            var model = notAcontroller.JustGetTheModel();

            Assert.That(model.HourlyForecasts.First().Weather, Is.Not.EqualTo(string.Empty));
            Assert.That(model.HourlyForecasts.First().Weather, Is.EqualTo(actualForecast));
        }
    }
}