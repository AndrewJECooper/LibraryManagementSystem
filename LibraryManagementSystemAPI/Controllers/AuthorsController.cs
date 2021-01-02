using AutoMapper;
using LibraryManagementSystemAPI.Dtos.AuthorDTOs;
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
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _repo;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadDto>>> GetAllAuthors()
        {
            var authorList = await _repo.GetAll();

            if(authorList == null)
            {
                return NotFound();
            }

            var authorDtoLst = _mapper.Map<IEnumerable<AuthorReadDto>>(authorList);
            return Ok(authorDtoLst);
        }

        [HttpGet("{id}", Name = "GetAuthorById")]
        public async Task<ActionResult<AuthorReadDto>> GetAuthorById(int id)
        {
            var author = await _repo.GetById(id);
            
            if(author == null)
            {
                return NotFound();
            }

            var authorDto = _mapper.Map<AuthorReadDto>(author);
            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorCreateDto>> CreateNewAuthor(Author authorTransferObject)
        {      
            var authorModel = _mapper.Map<Author>(authorTransferObject);

            await _repo.CreateNew(authorTransferObject);
            await _repo.Save();

            var authorReadDto = _mapper.Map<AuthorReadDto>(authorModel);

            return CreatedAtRoute(nameof(GetAuthorById), new { Id = authorReadDto.Id }, authorReadDto);
        }
    }
}
