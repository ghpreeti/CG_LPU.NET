using LMS.Models;

namespace LMS.Repository

{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task AddBook(Book book);

        Task DeleteBook(int id);
    }
}
