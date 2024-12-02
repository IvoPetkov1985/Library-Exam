using Library.Contracts;
using Library.Data;
using Library.Data.DataModels;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task AddBookToCollectionAsync(string userId, int id)
        {
            IdentityUserBook userEntry = new()
            {
                CollectorId = userId,
                BookId = id
            };

            if (await context.UsersBooks.ContainsAsync(userEntry) == false)
            {
                await context.UsersBooks.AddAsync(userEntry);

                await context.SaveChangesAsync();
            }
        }

        public async Task CreateBookAsync(BookAddFormModel model)
        {
            Book book = new()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.Url,
                Rating = model.Rating,
                CategoryId = model.CategoryId                
            };

            await context.Books.AddAsync(book);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookAllViewModel>> GetAllBooksAsync()
        {
            IEnumerable<BookAllViewModel> allBooks = await context.Books
                .AsNoTracking()
                .Select(b => new BookAllViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();

            return allBooks;
        }

        public async Task<IEnumerable<BookMineViewModel>> GetAllBooksInCollectionAsync(string userId)
        {
            IEnumerable<BookMineViewModel> booksInCollection = await context.UsersBooks
                .AsNoTracking()
                .Where(ub => ub.CollectorId == userId)
                .Select(ub => new BookMineViewModel()
                {
                    Id = ub.Book.Id,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    Description = ub.Book.Description,
                    ImageUrl = ub.Book.ImageUrl,
                    Category = ub.Book.Category.Name
                })
                .ToListAsync();

            return booksInCollection;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategoryViewModel> allCategories = await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return allCategories;
        }

        public async Task<bool> IsBookAvailableAsync(int id)
        {
            Book? book = await context.Books
                .AsNoTracking()
                .SingleOrDefaultAsync(b => b.Id == id);

            return book != null;
        }

        public async Task RemoveBookFromCollectionAsync(string userId, int id)
        {
            IdentityUserBook userEntry = new()
            {
                CollectorId = userId,
                BookId = id
            };

            if (await context.UsersBooks.ContainsAsync(userEntry))
            {
                context.UsersBooks.Remove(userEntry);

                await context.SaveChangesAsync();
            }
        }
    }
}
