using Library.Contracts;
using Library.Models.ViewModels;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService service;

        public BookController(IBookService bookService)
        {
            service = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await service.GetAllBooksAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = await service.GetMineBooksAsync(GetUserId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await service.GetNewAddBookModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            decimal rating;

            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0 and 10.");

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await service.AddBookAsync(model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await service.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = GetUserId();

            await service.AddBookToCollectionAsync(book, userId);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var bookToRemove = await service.GetBookByIdAsync(id);

            if (bookToRemove == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = GetUserId();

            await service.RemoveBookFromCollectionAsync(bookToRemove, userId);

            return RedirectToAction(nameof(Mine));
        }
    }
}
