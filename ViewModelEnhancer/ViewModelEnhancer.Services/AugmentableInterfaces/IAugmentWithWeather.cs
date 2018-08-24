using System;

namespace ViewModelEnhancer.Services.AugmentableInterfaces
{
    public interface IAugmentWithWeather
    {
        int Id { get; }
        DateTime Date { get; }
        string Weather { get; set; }
    }
}