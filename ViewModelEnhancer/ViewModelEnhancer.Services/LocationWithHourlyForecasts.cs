using System.Collections.Generic;

namespace ViewModelEnhancer.Services
{
    public class LocationWithHourlyForecasts
    {
        public IReadOnlyCollection<HourlyForecast> HourlyForecasts { get; set; }
    }

    public class HourlyForecast
    {
        public string Weather { get; set; }
    }
}