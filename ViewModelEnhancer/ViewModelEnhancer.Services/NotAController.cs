using System;
using System.Linq;

namespace ViewModelEnhancer.Services
{
    public class NotAController
    {
        private readonly IForecastService _forecastService;

        public NotAController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        private LocationWithHourlyForecasts GetModelWithNoForecasts()
        {
            return new LocationWithHourlyForecasts
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
        }

        public LocationWithHourlyForecasts JustGetTheModel()
        {
            var model = GetModelWithNoForecasts();
            _forecastService.AddHourlyForecastToModel(model);
            return model;
        }
    }
}
