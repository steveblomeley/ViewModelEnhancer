using ViewModelEnhancer.Services.AugmentableInterfaces;

namespace ViewModelEnhancer.Services.Augmenters
{
    public class DescriptionAugmenter : AugmenterBase<IAugmentWithDescription>
    {
        protected override void Augment(IAugmentWithDescription model)
        {
            model.Description = model.Id == 123 
                ? "Home of the industrial revolution, and shocking weather." 
                : "Somewhere next to Manchester.";
        }
    }
}