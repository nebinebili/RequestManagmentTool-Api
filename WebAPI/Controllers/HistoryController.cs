using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
           _historyService = historyService;
        }

        [HttpGet("GetAllByReqeustId")]
        public IActionResult GetAllByReqeustId(int requestid)
        {
            var result = _historyService.GetAllByReqeustId(requestid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
