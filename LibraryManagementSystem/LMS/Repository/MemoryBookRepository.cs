using LMS.Models;

namespace LMS.Repository
{
    public class MemoryBookRepository : IBookRepository
    {
        private List<Book> bookList = new List<Book>()
        {
           new Book{BookId = 101,Title = "Clean Code",Author = "Robert C. Martin",Price = 500 },
           new Book{BookId = 102,Title ="Design Patterns",Author = "GoF",Price = 1000 },
           new Book{BookId = 103,Title="Refactoring",Author="Martin Fowler",Price = 800 },
        };

        public Task AddBook(Book book)
        {
            bookList.Add(book);
            return Task.CompletedTask;
        }

        public Task DeleteBook(int id)
        {
            bookList.Remove(bookList.FirstOrDefault(b=>b.BookId==id));
            return Task.CompletedTask;

        }

        public Task<IEnumerable<Book>> GetAllBooks()
        {
            return Task.FromResult(bookList.AsEnumerable());
        }

        public Task<Book?> GetBookById(int id)
        {
            return Task.FromResult(bookList.FirstOrDefault(b => b.BookId == id));
        }
    }
}
