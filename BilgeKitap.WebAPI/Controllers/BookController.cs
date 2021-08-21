using AutoMapper;
using BilgeKitap.Business.Abstract;
using BilgeKitap.Entity;
using BilgeKitap.Entity.DTOs;
using Microsoft.AspNetCore.Authorization;
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
    public class BookController : ControllerBase
    {
        IBookService _bookService;
        IMapper _mapper;

        public BookController(IBookService bookService,IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
           
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int bookId)
        {
            var result = _bookService.GetById(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _bookService.GetListCategoryId(categoryId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbookdetail")]
        public IActionResult GetBookDetail(int bookId)
        {
            var result = _bookService.GetBookByID(bookId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }



        [HttpPost("add")]
        public IActionResult Add(Book book)
        {
            var result = _bookService.Add(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       


    }
}
