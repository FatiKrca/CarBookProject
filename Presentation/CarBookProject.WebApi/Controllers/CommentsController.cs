using CarBookProject.Application.Features.RepositoryPattern;
using CarBookProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentRepository.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {

            _commentRepository.Add(comment);
            return Ok("Comment Added");
        }
        [HttpGet("{id}")]
        public IActionResult CommentGetById(int id)
        {
            var values = _commentRepository.GetById(id);
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var values = _commentRepository.GetById(id);
            _commentRepository.Remove(values);
            return Ok("Comment Deleted");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Comment Updated");
        }
        [HttpGet("CommentListByBlog/{id}")]
        public IActionResult CommentListByBlogId(int id)
        {
            var values = _commentRepository.GetCommentsByBlogId(id);
            return Ok(values);
        }
    }
}
