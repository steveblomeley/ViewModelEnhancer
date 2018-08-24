using System.Collections.Generic;

namespace ViewModelEnhancer.Services.Augmenters
{
    public class MasterAugmenter : IMasterAugmenter
    {
        private readonly IEnumerable<IAugmenter> _augmenters;

        public MasterAugmenter(IEnumerable<IAugmenter> augmenters)
        {
            _augmenters = augmenters;
        }

        public void TryAugment(object model)
        {
            foreach (var augmenter in _augmenters)
            {
                augmenter.TryAugment(model);
            }
        }
    }
}