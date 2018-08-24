using System.Linq;
using ViewModelEnhancer.Services.AugmentableInterfaces;

namespace ViewModelEnhancer.Services.Augmenters
{
    public class HourlyForecastAugmenter<T> : AugmenterBase<IAugmentWithHourlyForecast<T>> where T : class, IHourlyForecast
    {
        protected override void Augment(IAugmentWithHourlyForecast<T> model)
        {
            var hourlyForecasts = model.HourlyForecasts.ToList();

            foreach (var hour in hourlyForecasts)
            {
                hour.Weather = "cold, wet and windy";
            }

            model.HourlyForecasts = hourlyForecasts;
        }
    }
}