using LibraryManagementSystemAPI.Enum;
using LibraryManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystemAPI.Dtos.BookDTOs
{
    public class BookReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Img { get; set; }

        public string Blurb { get; set; }

        public BookGenre Genre { get; set; }

        public Author Author { get; set; }
    }
}
