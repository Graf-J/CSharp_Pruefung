using BookRepository.Models;

namespace BookWebApplication.Models
{
    public class ViewBookModel
    {
        public List<Book> CurrentBooks { get; set; } = new();
        public List<Book> ArchivedBooks { get; set; } = new();
    }
}
