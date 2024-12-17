using Edu_Library.Data;
using Edu_Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edu_Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDB_Context _context;
        public BooksController(ApplicationDB_Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Book_tb> books = _context.Book_tb
                .Include(b => b.Category)
                .ToList();

            return View(books);
        }
    }
}
