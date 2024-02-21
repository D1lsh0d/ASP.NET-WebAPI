using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Library_WebAPI.Models;

namespace Library_WebAPI.Controllers
{

    public class BooksController : ApiController
    {
        LibraryEntities entities = new LibraryEntities();

        // GET: api/Books
        [HttpGet]
        public IQueryable<Models.Dtos.Books> GetBooks()
        {
            var books = from b in entities.Books
                        select new Models.Dtos.Books()
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Author = b.Author,
                            Description = b.Description,
                            PrintDate = b.PrintDate,
                        };

            return books;
        }

        // GET: api/Books/id
        [ResponseType(typeof(Models.Dtos.Books))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            Books book = await entities.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            Models.Dtos.Books bookDto = book.GetBookDto();

            return Ok(bookDto);
        }

        // POST:
        [HttpPost]
        public async Task<IHttpActionResult> AddBook(Books book)
        {
            if (book == null) { return BadRequest(); }

            entities.Books.Add(book);
            await entities.SaveChangesAsync();
            return Ok($"\"{book.Name}\" was succesfully added");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Books book = await entities.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            entities.Books.Remove(book);
            await entities.SaveChangesAsync();
            return Ok($"\"{book.Name}\" was succesfully deleted");
        }
    }
}