using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Blogs.Mediator.Results.BlogResults;
using MediatR;

namespace CarBookProject.Application.Blogs.Mediator.Queries.BlogQueries
{
    public class GetLast3BlogsWithAuthorsQuery : IRequest<List<Getlast3BlogsWithAuthorsQueryResult>>
    {
    }
}
