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
    public class AuthorRepo : IAuthorRepo
    {

        private readonly LMSContext _context;

        public AuthorRepo(LMSContext context)
        {
            _context = context;
        }

        public async Task CreateNew(Author data)
        {
            if(data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            await _context.Authors.AddAsync(data);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var authors = await _context.Authors.Include(x => x.Books).ToListAsync();
            return authors;
        }

        public async Task<Author> GetById(int id)
        {
            var author = await _context.Authors.Include(x => x.Books).FirstOrDefaultAsync(a => a.Id == id);
            return author;
        }

        public async Task UpdateData(Author data)
        {
            await _context.Update();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
