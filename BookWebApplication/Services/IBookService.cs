using BookRepository.Models;

namespace BookWebApplication.Services
{
    public interface IBookService
    {
        Task<List<CurrentBook>> GetCurrentBooksAsync();
        Task<List<ArchivedBook>> GetArchivedBooksAsync();
        Task MoveBookToArchiveAsync(int bookId);
        Task MoveBookToCurrentAsync(int bookId);
    }
}
