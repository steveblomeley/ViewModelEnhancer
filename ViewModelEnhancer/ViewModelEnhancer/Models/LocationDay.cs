using System;
using System.Collections.Generic;
using ViewModelEnhancer.Services.AugmentableInterfaces;

namespace ViewModelEnhancer.Models
{
    public class LocationDay : IAugmentWithHourlyForecast<HourlyForecast>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<HourlyForecast> HourlyForecasts { get; set; }
    }
}