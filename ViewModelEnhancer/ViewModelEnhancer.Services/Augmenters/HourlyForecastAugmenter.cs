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
                var hours = hour.Hour.Hours;

                if (hours % 3 == 0)
                {
                    hour.Weather = "hot and sunny";
                }
                else if (hours % 5 == 0)
                {
                    hour.Weather = "breezy for the time of year";
                }
                else
                {
                    hour.Weather = "cold, wet and windy";
                }
            }

            model.HourlyForecasts = hourlyForecasts;
        }
    }
}