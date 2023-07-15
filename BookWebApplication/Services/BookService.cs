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

        public async Task<List<CurrentBook>> GetCurrentBooksAsync()
        {
            var currentBooks = await _context.CurrentBooks.ToListAsync();

            return currentBooks;
        }


        public async Task<List<ArchivedBook>> GetArchivedBooksAsync()
        {
            var archivedBooks = await _context.ArchivedBooks.ToListAsync();

            return archivedBooks;
        }

        public async Task MoveBookToCurrentAsync(int bookId)
        {
            // Find the Book which has to be moved by its ID
            var bookToMove = await _context.ArchivedBooks.FirstOrDefaultAsync(book => book.Id == bookId);

            // If the Book is not found return
            if (bookToMove == null)
                return;

            // Create the CurrentBook
            var currentBook = new CurrentBook
            {
                Titel = bookToMove.Titel,
                Autor = bookToMove.Autor
            };

            // Move the Book to the CurrentBooks
            _context.ArchivedBooks.Remove(bookToMove);
            await _context.CurrentBooks.AddAsync(currentBook);
            await _context.SaveChangesAsync();
        }

        public async Task MoveBookToArchiveAsync(int bookId)
        {
            // Find the Book which has to be moved by its ID
            var bookToMove = await _context.CurrentBooks.FirstOrDefaultAsync(book => book.Id == bookId);

            // If the Book is not found return
            if (bookToMove == null)
                return;

            // Create the ArchivedBook
            var archivedBook = new ArchivedBook
            {
                Titel = bookToMove.Titel,
                Autor = bookToMove.Autor
            };

            // Move the Book to the ArchivedBooks
            _context.CurrentBooks.Remove(bookToMove);
            await _context.ArchivedBooks.AddAsync(archivedBook);
            await _context.SaveChangesAsync();
        }
    }
}
