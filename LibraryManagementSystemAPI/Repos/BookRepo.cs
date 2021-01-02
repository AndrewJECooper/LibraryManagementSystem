using LibraryManagementSystemAPI.DataContext;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystemAPI.Repos
{
    public class BookRepo : IBookRepo
    {
        private readonly LMSContext _context;

        public BookRepo(LMSContext context)
        {
            _context = context;
        }

        public async Task CreateNew(Book data)
        {
            if(data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            await _context.AddAsync(data);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var books = await _context.Books.Include(x => x.Author).ToListAsync();
            return books;
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
