using AutoMapper;
using LibraryManagementSystemAPI.Dtos.BookDTOs;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _repo;
        private readonly IMapper _mapper;

        public BooksController(IBookRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadDto>>> GetAllBooks()
        {
            var bookLst = await _repo.GetAll();

            if(bookLst == null)
            {
                return NotFound();
            }

            var bookLstDto = _mapper.Map<IEnumerable<BookReadDto>>(bookLst);
            return Ok(bookLstDto);
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<ActionResult<BookReadDto>> GetBookById(int id)
        {
            var book = await _repo.GetById(id);

            if(book == null)
            {
                return NotFound();
            }

            var bookDto = _mapper.Map<BookReadDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<ActionResult<BookCreateDto>> CreateNewBook(Book bookObj)
        {
            var bookModel = _mapper.Map<Book>(bookObj);

            await _repo.CreateNew(bookObj);
            await _repo.Save();

            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);

            return CreatedAtRoute(nameof(GetBookById), new { Id = bookReadDto.Id }, bookReadDto);
        }
    }
}
