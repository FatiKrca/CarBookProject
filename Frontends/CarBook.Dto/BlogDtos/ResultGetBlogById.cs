using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BlogDtos
{
    public class ResultGetBlogById
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }

        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }


        // FK + Navigation (Author)


        // FK + Navigation (Category)
        public int CategoryId { get; set; }
    }
}
