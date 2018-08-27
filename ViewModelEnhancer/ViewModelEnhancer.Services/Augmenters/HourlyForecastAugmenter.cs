using System.Linq;
using ViewModelEnhancer.Services.AugmentableInterfaces;

namespace ViewModelEnhancer.Services.Augmenters
{
    public class HourlyForecastAugmenter<T> : AugmenterBase<IAugmentWithHourlyForecast<T>> where T : class, IHourlyForecast
    {
        protected override void Augment(IAugmentWithHourlyForecast<T> model)
        {
            foreach (var forecast in model.HourlyForecasts)
            {
                var hours = forecast.Time.Hours;

                if (hours % 3 == 0)
                {
                    forecast.Weather = "hot and sunny";
                }
                else if (hours % 5 == 0)
                {
                    forecast.Weather = "breezy for the time of year";
                }
                else
                {
                    forecast.Weather = "cold, wet and windy";
                }
            }
        }
    }
}