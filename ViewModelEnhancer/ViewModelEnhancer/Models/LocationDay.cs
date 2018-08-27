using System.Collections.Generic;

namespace ViewModelEnhancer.Models
{
    public class LocationWithHourlyForecasts
    {
        public string Name { get; set; }
        public IEnumerable<HourlyForecast> HourlyForecasts { get; set; }
    }
}