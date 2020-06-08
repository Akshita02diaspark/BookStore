using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int>  AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };
         await   _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var Books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                foreach(var book in allbooks)
                {
                    Books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages

                    });
                }
            }
            return Books;

        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book =await _context.Books.FindAsync(id);
            if (book !=null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;
        }
        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title ="Java",Author="akshita" ,Description="Description about java",Category="Action",TotalPages="2000",Language="English"},
                new BookModel(){Id=2,Title ="C++",Author="jagruti",Description="Description about C++",Category="Drama",TotalPages="1700",Language="English"},
                new BookModel(){Id=3,Title ="DotNet",Author="harsh",Description="Description about DotNet",Category="Action",TotalPages="2100",Language="English"},
                new BookModel(){Id=4,Title ="C#",Author="ayushi",Description="Description about C#",Category="Action",TotalPages="1000",Language="English"},



            };
        }
    }
}
