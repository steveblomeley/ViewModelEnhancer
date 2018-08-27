using System;
using ViewModelEnhancer.Services.AugmentableInterfaces;

namespace ViewModelEnhancer.Models
{
    public class HourlyForecast : IHourlyForecast
    {
        public TimeSpan Time { get; set; }
        public string Weather { get; set; }
    }
}