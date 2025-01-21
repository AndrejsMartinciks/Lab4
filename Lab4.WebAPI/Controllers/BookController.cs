using Lab2.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private AuthorDbContext _db;

        public BookController()
        {
            _db = new AuthorDbContext();
        }

        [HttpGet]
        public Book[] GetBooks()
        {
            var data = _db.Books.ToArray();
            return data;
        }

        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            var data = _db.Books.FirstOrDefault(s => s.Id == id);
            return data;
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            var data = _db.Books.FirstOrDefault(s => s.Id == id);

            if (data != null)
            {
                _db.Books.Remove(data);
                _db.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void UpdateBook([FromBody] Book book, int id)
        {
            var existingBook = _db.Books.FirstOrDefault(s => s.Id == id);

            if (existingBook != null)
            {
                existingBook.Id = book.Id;
                existingBook.Title = book.Title;
                existingBook.Year = book.Year;
                existingBook.Grade = book.Grade;
            }
            _db.SaveChanges();
        }
    }
}
