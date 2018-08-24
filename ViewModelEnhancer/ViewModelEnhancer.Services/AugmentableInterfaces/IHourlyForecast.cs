using System;

namespace ViewModelEnhancer.Services.AugmentableInterfaces
{
    public interface IHourlyForecast
    {
        TimeSpan Hour { get; set; }
        string Weather { get; set; }
    }
}