using ViewModelEnhancer.Services.AugmentableInterfaces;

namespace ViewModelEnhancer.Services.Augmenters
{
    public class CommentsAugmenter : AugmenterBase<IAugmentWithComments>
    {
        protected override void Augment(IAugmentWithComments model)
        {
            model.Comments = new[] {"First comment", "second comment", "third one"};
        }
    }
}