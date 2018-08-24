using ViewModelEnhancer.Services.AugmentableInterfaces;

namespace ViewModelEnhancer.Services.Augmenters
{
    public class WeatherAugmenter : AugmenterBase<IAugmentWithWeather>
    {
        protected override void Augment(IAugmentWithWeather model)
        {
            model.Weather = "Bright sun with occasional heavy downpours, prolonged at times.";
        }
    }
}