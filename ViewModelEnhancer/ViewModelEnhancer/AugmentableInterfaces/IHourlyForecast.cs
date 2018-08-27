using System;

namespace ViewModelEnhancer.Services.AugmentableInterfaces
{
    public interface IHourlyForecast
    {
        TimeSpan Time { get; set; }
        string Weather { get; set; }
    }
}