using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Blogs.Mediator.Results.BlogResults
{
    public class Getlast3BlogsWithAuthorsQueryResult
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }


        // FK + Navigation (Author)
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public string AuthorDescription { get; set; }

        // FK + Navigation (Category)
        public int CategoryId { get; set; }
    }
}
