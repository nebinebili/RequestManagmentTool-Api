using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;

        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] AddCommentDto commentDto)
        {
            var result = _commentService.Add(commentDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllByRequestid")]
        public IActionResult GetAllByRequestid(int requestid)
        {
            var result = _commentService.GetAllByRequestid(requestid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("AddFileToComment")]
        public IActionResult AddFileToComment([FromForm] AddFileToCommentDto addFileToCommentDto)
        {
            var result = _commentService.AddFileToComment(addFileToCommentDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
