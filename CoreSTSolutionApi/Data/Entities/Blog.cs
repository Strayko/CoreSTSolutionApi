using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreSTSolutionApi.Data.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string LongDescription { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public ICollection<Tag> Tags { get; set; }
        
        public string Notes { get; set; }
    }
}