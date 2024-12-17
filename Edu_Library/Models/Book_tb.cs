using System.ComponentModel.DataAnnotations;

namespace Edu_Library.Models
{
    public class Book_tb
    {
        [Key]

        public int BookId { get; set; }
        public string Name { get; set; }
        public string Detail {  get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; } 
        public int CategoryId { get; set; }
        public Category_tb Category { get; set; }
    }
}
