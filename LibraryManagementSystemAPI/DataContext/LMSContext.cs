using LibraryManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystemAPI.DataContext
{
    public class LMSContext : DbContext
    {
        public LMSContext(DbContextOptions<LMSContext> opt) : base(opt)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
