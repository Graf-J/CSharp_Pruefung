using BookRepository.Data;
using BookRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRepository.Services
{
    /// <summary>
    /// Service class for handling book-related operations.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the BookService class with the provided DataContext.
        /// </summary>
        /// <param name="context">The DataContext to be used for database operations.</param>
        public BookService(DataContext context)
        {
            _context= context;
        }

        /// <summary>
        /// Retrieves a list of current books asynchronously from the database.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation. The task result contains the list of current books.</returns>
        public async Task<List<CurrentBook>> GetCurrentBooksAsync()
        {
            var currentBooks = await _context.CurrentBooks.ToListAsync();

            return currentBooks;
        }

        /// <summary>
        /// Retrieves a list of archived books asynchronously from the database.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation. The task result contains the list of archived books.</returns>
        public async Task<List<ArchivedBook>> GetArchivedBooksAsync()
        {
            var archivedBooks = await _context.ArchivedBooks.ToListAsync();

            return archivedBooks;
        }

        /// <summary>
        /// Moves a book from archived books to current books asynchronously.
        /// </summary>
        /// <param name="bookId">The ID of the book to be moved.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
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

        /// <summary>
        /// Moves a book from current books to archived books asynchronously.
        /// </summary>
        /// <param name="bookId">The ID of the book to be moved.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
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
