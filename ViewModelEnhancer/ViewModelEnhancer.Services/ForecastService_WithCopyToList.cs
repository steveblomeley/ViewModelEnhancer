using System.Linq;

namespace ViewModelEnhancer.Services
{
    public class ForecastService_WithCopyToList : IForecastService
    {
        private readonly string _actualForecast;

        public ForecastService_WithCopyToList(string actualForecast)
        {
            _actualForecast = actualForecast;
        }

        public void AddHourlyForecastToModel(LocationWithHourlyForecasts model)
        {
            var hourlyForecasts = model.HourlyForecasts.ToList();

            foreach (var forecast in hourlyForecasts)
            {
                forecast.Weather = _actualForecast;
            }

            model.HourlyForecasts = hourlyForecasts;
        }
    }
}