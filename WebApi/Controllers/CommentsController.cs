using Business.Abstract;
using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost("add")]
        public IActionResult AddComment([FromBody] CommentDto commentDto)
        {
            var result = _commentService.Add(commentDto);
            return result.Success 
                ? Ok(result) 
                : BadRequest(result);
        }
        [HttpDelete("delete/{commentId}")]
        public IActionResult DeleteComment(Guid commentId)
        {
            var result = _commentService.Delete(commentId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpPut("update/{commentId}")]
        public IActionResult UpdateComment([FromBody] CommentDto commentDto, Guid commentId)
        {
            var result = _commentService.Update(commentDto, commentId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpGet("getAllCommentByProductId/{productId}")]
        public IActionResult GetAllCommentByProductId(Guid productId)
        {
            var result = _commentService.GetAllCommentByProductId(productId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpGet("etAllCommentByUserId/{userId}")]
        public IActionResult GetAllCommentByUserId(Guid userId)
        {
            var result = _commentService.GetAllCommentByUserId(userId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}
