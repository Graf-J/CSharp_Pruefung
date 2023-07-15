using BookRepository.Models;

namespace BookWebApplication.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetCurrentBooks();
        Task<List<Book>> GetArchivedBooks();
    }
}
