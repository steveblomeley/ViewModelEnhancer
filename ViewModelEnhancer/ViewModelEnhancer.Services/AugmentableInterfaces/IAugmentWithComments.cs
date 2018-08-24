using System;
using System.Collections.Generic;

namespace ViewModelEnhancer.Services.AugmentableInterfaces
{
    public interface IAugmentWithComments
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        IEnumerable<string> Comments { get; set; }
    }
}