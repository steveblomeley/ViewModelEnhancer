using System;
using System.Collections.Generic;

namespace ViewModelEnhancer.Services.AugmentableInterfaces
{
    public interface IAugmentWithHourlyForecast<T> where T : IHourlyForecast
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        IEnumerable<T> HourlyForecasts { get; set; }
    }
}