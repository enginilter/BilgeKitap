using BilgeKitap.Business.Abstract;
using BilgeKitap.Core.Aspects.Logging;
using BilgeKitap.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeKitap.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        IBookCategoryService _bookCategoryService;
        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpGet("getall")]
        [LogAspect(typeof(FileLogger))]
        public IActionResult GetAll()
        {
            var result = _bookCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _bookCategoryService.GetByID(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
