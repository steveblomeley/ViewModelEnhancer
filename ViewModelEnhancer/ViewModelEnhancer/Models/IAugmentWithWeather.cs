using System;

namespace ViewModelEnhancer.Models
{
    public interface IAugmentWithWeather
    {
        int Id { get; }
        DateTime Date { get; }
        string Weather { get; set; }
    }
}