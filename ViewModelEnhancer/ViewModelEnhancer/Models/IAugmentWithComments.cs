using System;
using System.Collections.Generic;

namespace ViewModelEnhancer.Models
{
    public interface IAugmentWithComments
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        IEnumerable<string> Comments { get; set; }
    }
}