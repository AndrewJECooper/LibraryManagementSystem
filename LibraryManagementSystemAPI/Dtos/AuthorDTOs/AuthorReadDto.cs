using LibraryManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystemAPI.Dtos.AuthorDTOs
{
    public class AuthorReadDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Img { get; set; }

        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
