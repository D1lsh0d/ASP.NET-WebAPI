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
    }
}