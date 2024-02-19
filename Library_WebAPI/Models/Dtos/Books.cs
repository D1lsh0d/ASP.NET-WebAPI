using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_WebAPI.Models.Dtos
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> PrintDate { get; set; }
    }
}