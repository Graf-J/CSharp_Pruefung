using BookWebApplication.Models;
using BookWebApplication.Services;
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

            return View(model);
        }

        [HttpPost]
        public IActionResult MoveBookToArchive(int bookId)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MoveBookToCurrent(int bookId) 
        {
            return RedirectToAction("Index");
        }
    }
}
