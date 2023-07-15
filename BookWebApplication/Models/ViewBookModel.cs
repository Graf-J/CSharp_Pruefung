using BookRepository.Models;

namespace BookWebApplication.Models
{
    public class ViewBookModel
    {
        public List<CurrentBook> CurrentBooks { get; set; } = new();
        public List<ArchivedBook> ArchivedBooks { get; set; } = new();
    }
}
