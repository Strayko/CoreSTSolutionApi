using System.Collections.Generic;

namespace CoreSTSolutionApi.Models
{
    public class BlogModel
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        
        public string Category { get; set; }
        public string Description { get; set; }

        public ICollection<TagModel> Tags { get; set; }
    }
}