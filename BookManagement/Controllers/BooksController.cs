using BookManagement.Data;
using BookManagement.Models;
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

        //Get: Books/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Book());
        }

        //Post: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        //Get: Books/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //Post: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _repository.Update(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}
