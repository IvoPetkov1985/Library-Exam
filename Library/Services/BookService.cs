using Library.Contracts;
using Library.Data;
using Library.Data.DataModels;
using Library.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext data)
        {
            context = data;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Rating = decimal.Parse(model.Rating)
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(BookCollectionViewModel model, string userId)
        {
            bool isAlreadyAdded = await context.UsersBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == model.Id);

            if (isAlreadyAdded == false)
            {
                var userBook = new IdentityUserBook()
                {
                    BookId = model.Id,
                    CollectorId = userId
                };

                await context.UsersBooks.AddAsync(userBook);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await context.Books
                .Select(b => new AllBookViewModel()
                {
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    Category = b.Category.Name

                })
                .ToListAsync();
        }

        public async Task<BookCollectionViewModel?> GetBookByIdAsync(int id)
        {
            return await context.Books
                .Where(b => b.Id == id)
                .Select(b => new BookCollectionViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Url = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId)
        {
            return await context.UsersBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new MineBookViewModel()
                {
                    Id = b.BookId,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            var model = new AddBookViewModel()
            {
                Categories = categories
            };

            return model;
        }

        public async Task RemoveBookFromCollectionAsync(BookCollectionViewModel model, string userId)
        {
            var userBookToRemove = await context.UsersBooks
                .FirstOrDefaultAsync(ub => ub.BookId == model.Id && ub.CollectorId == userId);

            if (userBookToRemove != null)
            {
                context.UsersBooks.Remove(userBookToRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}
