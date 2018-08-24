namespace ViewModelEnhancer.Augmenters
{
    public class MasterAugmenter : IMasterAugmenter
    {
        private readonly IAugmenter _augmenter;

        public MasterAugmenter(IAugmenter augmenter)
        {
            _augmenter = augmenter;
        }

        public void TryAugment(object model)
        {
            _augmenter.TryAugment(model);
        }
    }
}