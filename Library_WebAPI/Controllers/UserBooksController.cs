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
    public class UserBooksController : ApiController
    {
        LibraryEntities entities = new LibraryEntities();

        // GET: UserBooks
        [HttpGet]
        public IQueryable<Models.Dtos.UserBooks> GetUserBooks()
        {
            var userBooks = from b in entities.UserBooks
                            select new Models.Dtos.UserBooks()
                            {
                                UserBookID = b.UserBookID,
                                UserID = b.UserID,
                                BookID = b.BookID,
                                CheckoutDate = b.CheckoutDate,
                                ReturnDate = b.ReturnDate
                            };
            return userBooks;
        }
        // POST:
        [HttpPost]
        public async Task<IHttpActionResult> AddUserBooks(UserBooks userBook)
        {
            if (userBook == null) { return BadRequest(); }

            entities.UserBooks.Add(userBook);
            await entities.SaveChangesAsync();
            return Ok("Record was succesfully added");
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateRecord(UserBooks record)
        {
            if (record == null)
            {
                return BadRequest();
            }

            try
            {
                var foundRecord = entities.UserBooks.FirstOrDefault(b => b.UserBookID == record.UserBookID);

                if (foundRecord == null)
                {
                    return NotFound();
                }

                // Обновление свойств существующей записи с использованием значений из переданного объекта book
                foundRecord.BookID = record.BookID;
                foundRecord.UserID = record.UserID;
                foundRecord.ReturnDate = record.ReturnDate;
                foundRecord.CheckoutDate = record.CheckoutDate;

                await entities.SaveChangesAsync();

                return Ok("Record was succesfully updated");
            }
            catch (Exception ex)
            {
                // Обработка ошибок при обновлении записи
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRecord(int id)
        {
            UserBooks record = await entities.UserBooks.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            entities.UserBooks.Remove(record);
            await entities.SaveChangesAsync();
            return Ok("Record was succesfully deleted");
        }
    }
}