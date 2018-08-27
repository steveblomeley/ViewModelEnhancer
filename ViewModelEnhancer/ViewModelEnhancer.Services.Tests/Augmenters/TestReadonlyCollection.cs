using System.Collections.Generic;
using System.Linq;

namespace ViewModelEnhancer.Services.Tests.Augmenters
{
    public class TestReadonlyCollection
    {
        private void DoIEnumerableStuff()
        {
            var ienumerableStrings = Enumerable.Empty<string>();

            var count = ienumerableStrings.Count();
            var first = ienumerableStrings.FirstOrDefault();
        }

        private void DoReadonlyStuff()
        {
            IReadOnlyCollection<string> readonlyStrings = Enumerable.Empty<string>().ToList();

            var count = readonlyStrings.Count();
            var first = readonlyStrings.FirstOrDefault();
        }
    }
}