using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestInfoController : ControllerBase
    {
        private readonly IRequestInfoService _requestInfoService;

        public RequestInfoController(IRequestInfoService requestInfoService)
        {
           _requestInfoService=requestInfoService;
        }

        [HttpPost("Add")]
        public IActionResult Add(RequestInfoDto requestInfoDto)
        {
            var result = _requestInfoService.Add(requestInfoDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByRequestId")]
        public IActionResult Get(int requestId)
        {
            var result = _requestInfoService.GetByRequestId(requestId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
