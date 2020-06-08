using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        public async Task<ViewResult> GetAllBooks()
        {

            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public ViewResult AddBook(bool isSuccess = false , int BookId = 0 )
        {
            ViewBag.Bookid = BookId;
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction("AddBook", new { isSuccess = true, BookId = id });
                }
            }
         
            return View();
        }

        public List<BookModel> SearchBooks(string bookName , string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
            }
}
