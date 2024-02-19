using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library_WebAPI.Models.Dtos;

namespace Library_WebAPI.Models
{
    public static class BookDtoExtensionMethod
    {
        public static Models.Dtos.Books GetBookDto(this Books book)
        {
            return new Models.Dtos.Books()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Description = book.Description,
                PrintDate = book.PrintDate
            };
        }

       
    }
}