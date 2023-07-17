using BookWebApplication.Models;
using BookRepository.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWebApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        async public Task<IActionResult> Index()
        {
            // Load Books in parallel
            var currentBooks = await _bookService.GetCurrentBooksAsync();
            var archivedBooks = await _bookService.GetArchivedBooksAsync();

            // Place Books into the ViewBookModel
            var model = new ViewBookModel {
                CurrentBooks = currentBooks,
                ArchivedBooks = archivedBooks
            };

            // Return the Website to the Client
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MoveBookToArchive(int bookId)
        {
            // Move the books from Current to Archive
            await _bookService.MoveBookToArchiveAsync(bookId);

            // Redirect back to the Index Page
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MoveBookToCurrent(int bookId) 
        {
            // Move the books from Archive to Current
            await _bookService.MoveBookToCurrentAsync(bookId);

            // Redirect back to the Index Page
            return RedirectToAction("Index");
        }
    }
}
