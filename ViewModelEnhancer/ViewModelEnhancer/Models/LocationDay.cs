using System;
using System.Collections.Generic;

namespace ViewModelEnhancer.Models
{
    public interface IHourlyForecast
    {
        TimeSpan Hour { get; set; }
        string Weather { get; set; }
    }

    public interface ILocationDay<T> where T : IHourlyForecast
    {
        int LocationId { get; set; }
        DateTime Date { get; set; }
        IEnumerable<T> HourlyForecasts { get; set; }
    }

    public class HourlyForecast : IHourlyForecast
    {
        public TimeSpan Hour { get; set; }
        public string Weather { get; set; }
    }

    public class LocationDay : ILocationDay<HourlyForecast>
    {
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<HourlyForecast> HourlyForecasts { get; set; }
    }
}
