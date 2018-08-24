namespace ViewModelEnhancer.Augmenters
{
    public interface IAugmenter
    {
        void TryAugment(object viewModel);
    }
}