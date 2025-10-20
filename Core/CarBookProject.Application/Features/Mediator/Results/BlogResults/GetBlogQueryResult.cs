using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Blogs.Mediator.Results.BlogResults
{
    public class GetBlogQueryResult
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }


        // FK + Navigation (Author)
        public int AuthorId { get; set; }

        // FK + Navigation (Category)
        public int CategoryId { get; set; }
    }
}
