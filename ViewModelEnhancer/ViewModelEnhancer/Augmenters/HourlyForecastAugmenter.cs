using System.Linq;
using ViewModelEnhancer.Models;

namespace ViewModelEnhancer.Augmenters
{
    public class HourlyForecastAugmenter : IAugmenter
    {
        public void TryAugment(object o)
        {
            if (!(o is LocationWithHourlyForecasts model)) return;

            var hourlyForecasts = model.HourlyForecasts.ToList();

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

            model.HourlyForecasts = hourlyForecasts;
        }
    }
}