using ViewModelEnhancer.Models;

namespace ViewModelEnhancer.Augmenters
{
    public class CommentsAugmenter : AugmenterBase<IAugmentWithComments>
    {
        protected override void Augment(IAugmentWithComments model)
        {
            model.Comments = new[] {"First comment", "second comment", "third one"};
        }
    }
}