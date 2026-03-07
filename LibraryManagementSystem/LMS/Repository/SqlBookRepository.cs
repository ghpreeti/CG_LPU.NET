using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repository
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public SqlBookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
           await _context.Books.Where(b => b.BookId == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
           return await _context.Books.ToListAsync();
           
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
        }
    }
}
