

namespace CarBookProject.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string CoverImageUrl { get; set; }  
        public DateTime CreatedDate { get; set; }

        // FK + Navigation (Author)
        public int AuthorId { get; set; }
        public Author Author { get; set; }  

        // FK + Navigation (Category)
        public int CategoryId { get; set; }
        public Category Category { get; set; }  

    }
}
