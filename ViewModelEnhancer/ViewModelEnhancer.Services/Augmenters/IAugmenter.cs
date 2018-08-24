namespace ViewModelEnhancer.Services.Augmenters
{
    public interface IAugmenter
    {
        void TryAugment(object viewModel);
    }
}