using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystemAPI.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(2000)]
        public string FirstName { get; set; }

        [Required, MaxLength(2000)]
        public string Surname { get; set; }

        public string Img { get; set; }

        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
