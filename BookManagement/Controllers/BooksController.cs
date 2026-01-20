using BookManagement.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookRepository _repository;

        public BooksController(BookRepository repository) 
        { 
            _repository = repository;
        }

        public IActionResult Index()
        {
            var books = _repository.GetAll();

            return View(books);
        }
    }
}
