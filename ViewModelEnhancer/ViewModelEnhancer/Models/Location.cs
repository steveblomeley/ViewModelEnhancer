using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewModelEnhancer.Models
{
    public class Location : IAugmentWithWeather, IAugmentWithComments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Weather { get; set; }
        public IEnumerable<string> Comments { get; set; } = Enumerable.Empty<string>();
    }
}