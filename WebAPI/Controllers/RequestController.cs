using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;


        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("GetAllMyRequest")]
        public IActionResult GetAllMyRequest(short? statusid)
        {
            var result = _requestService.GetAllMyRequest(statusid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetMyRequestsCount")]
        public IActionResult GetMyRequestsCount()
        {
            var result = _requestService.GetMyRequestsCount();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByCategoryId")]
        public IActionResult GetByCategoryId(short? categoryid, short? statusid)
        {
            var result = _requestService.GetAllRequestByCategoryId(categoryid,statusid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetRequestsCountByCategoryId")]
        public IActionResult GetRequestCountByCategoryId(short? categoryid)
        {
            var result = _requestService.GetRequestsCountByCategoryId(categoryid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetReportOfRequest")]
        public IActionResult GetReportOfRequest(int requestid)
        {
            var result = _requestService.GetReportOfRequestDto(requestid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(CreateRequestDto createRequestDto)
        {
            var result = _requestService.Add(createRequestDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
