using System.Collections.Generic;

namespace ViewModelEnhancer.Services
{
    public class LocationWithHourlyForecasts
    {
        public IEnumerable<HourlyForecast> HourlyForecasts { get; set; }
    }
}