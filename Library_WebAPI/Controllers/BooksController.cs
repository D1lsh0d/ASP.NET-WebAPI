﻿using System;
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

        /// <summary>
        /// Gets list of Books from the server
        /// </summary>
        /// <returns>list of Books DTO</returns>
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
                            Quantity = b.Quantity
                        };

            return books;
        }

        // GET: api/Books/id
        /// <summary>
        /// Gets the book by Id from the server
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Book DTO</returns>
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

        /// <summary>
        /// Adds the book to the server
        /// </summary>
        /// <param name="book">Book model</param>
        /// <returns>Action result</returns>
        [HttpPost]
        public async Task<IHttpActionResult> AddBook(Books book)
        {
            if (book == null) { return BadRequest(); }

            entities.Books.Add(book);
            await entities.SaveChangesAsync();
            return Ok($"\"{book.Name}\" was succesfully added");
        }
        /// <summary>
        /// Deletes the book by Id
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Action result</returns>
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
            return Ok($"Book: \"{book.Name}\" was succesfully deleted");
        }
        /// <summary>
        /// Updates the book data on the server
        /// </summary>
        /// <param name="book">Book model</param>
        /// <returns>Action result</returns>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateBook(Books book) {
            if (book == null)
            {
                return BadRequest();
            }

            try
            {
                var foundBook = entities.Books.FirstOrDefault(b => b.Id == book.Id);

                if (foundBook == null)
                {
                    return NotFound();
                }

                // Обновление свойств существующей записи с использованием значений из переданного объекта book
                foundBook.Name = book.Name;
                foundBook.Author = book.Author;
                foundBook.PrintDate = book.PrintDate;
                foundBook.Description = book.Description;
                foundBook.Quantity = book.Quantity;

                await entities.SaveChangesAsync();

                return Ok("Book was succesfully updated");
            }
            catch (Exception ex)
            {
                // Обработка ошибок при обновлении записи
                return InternalServerError(ex);
            }
        }
    }
}