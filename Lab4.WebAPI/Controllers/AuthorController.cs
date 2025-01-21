using Lab2.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private AuthorDbContext _db;

        public AuthorController()
        {
            _db = new AuthorDbContext();
        }

        [HttpGet]
        public Author[] GetAuthors()
        {
            var data = _db.Authors.ToArray();
            return data;
        }

        [HttpGet("{id}")]
        public Author GetAuthor(int id)
        {
            var data = _db.Authors.FirstOrDefault(s => s.Id == id);
            return data;
        }

        [HttpPost]
        public void Post([FromBody] Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteAuthor(int id)
        {
            var data = _db.Authors.FirstOrDefault(s => s.Id == id);

            if (data != null)
            {
                _db.Authors.Remove(data);
                _db.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void UpdateAuthor([FromBody] Author author, int id)
        {
            var existingAuthor = _db.Authors.FirstOrDefault(s => s.Id == id);

            if (existingAuthor != null)
            {
                existingAuthor.Id = author.Id;
                existingAuthor.Name = author.Name;
                existingAuthor.Surname = author.Surname;
                existingAuthor.Country = author.Country;
            }
            _db.SaveChanges();
        }
    }
}
