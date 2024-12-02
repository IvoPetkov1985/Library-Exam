using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookToCollectionAsync(string userId, int id);

        Task CreateBookAsync(BookAddFormModel model);

        Task<IEnumerable<BookAllViewModel>> GetAllBooksAsync();

        Task<IEnumerable<BookMineViewModel>> GetAllBooksInCollectionAsync(string userId);

        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

        Task<bool> IsBookAvailableAsync(int id);

        Task RemoveBookFromCollectionAsync(string userId, int id);
    }
}
