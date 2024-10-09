using Library.Models.ViewModels;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId);

        Task<AddBookViewModel> GetNewAddBookModelAsync();

        Task AddBookAsync(AddBookViewModel model);

        Task<BookCollectionViewModel?> GetBookByIdAsync(int id);

        Task AddBookToCollectionAsync(BookCollectionViewModel model, string userId);

        Task RemoveBookFromCollectionAsync(BookCollectionViewModel model, string userId);
    }
}
