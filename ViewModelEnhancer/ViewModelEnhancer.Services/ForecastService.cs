namespace ViewModelEnhancer.Services
{
    public class ForecastService : IForecastService
    {
        private readonly string _actualForecast;

        public ForecastService(string actualForecast)
        {
            _actualForecast = actualForecast;
        }

        public void AddHourlyForecastToModel(LocationWithHourlyForecasts model)
        {
            foreach (var forecast in model.HourlyForecasts)
            {
                forecast.Weather = _actualForecast;
            }
        }
    }
}