using LMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repo;

        public BookController(IBookRepository repo)
        {
            _repo = repo;
        }

        // GET: BookController
        public async Task<ActionResult> List()
        {
            var books = await _repo.GetAllBooks();
                return View(books);
        }

        // GET: BookController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var book = await _repo.GetBookById(id);
            return View(book);
        }

        // GET: BookController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book b)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repo.AddBook(b);
                    return RedirectToAction(nameof(List));
                }
                return View(b);
            }
            catch
            {
                return View();
            }
        }


        // GET: BookController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var book = await _repo.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _repo.DeleteBook(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
