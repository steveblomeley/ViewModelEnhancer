namespace ViewModelEnhancer.Services.Augmenters
{
    public abstract class AugmenterBase<TAugmentable> : IAugmenter
    {
        public void TryAugment(object model)
        {
            if (model is TAugmentable augmentableModel)
            {
                Augment(augmentableModel);
            }
        }

        protected abstract void Augment(TAugmentable model);
    }
}