using AutoMapper;
using LibraryManagementSystemAPI.Dtos.BookDTOs;
using LibraryManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystemAPI.Profiles.BookProfiles
{
    public class BookProfiles : Profile
    {
        public BookProfiles()
        {
            CreateMap<Book, BookReadDto>();
        }   
    }
}
