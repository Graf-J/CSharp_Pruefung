using BookRepository.Data;
using BookRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApplication.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context= context;
        }

        public async Task<List<Book>> GetCurrentBooks()
        {
            var currentBooks = await _context.CurrentBooks.ToListAsync();

            return currentBooks;
        }


        public async Task<List<Book>> GetArchivedBooks()
        {
            var archivedBooks = await _context.ArchivedBooks.ToListAsync();

            return archivedBooks;
        }
    }
}
