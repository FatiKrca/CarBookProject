using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Blogs.Mediator.Results.BlogResults
{
    public class GetBlogByIdQueryResult
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        // FK + Navigation (Author)
        public int AuthorId { get; set; }

        // FK + Navigation (Category)
        public int CategoryId { get; set; }
    }
}
