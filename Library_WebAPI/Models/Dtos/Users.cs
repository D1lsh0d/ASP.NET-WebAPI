using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_WebAPI.Models.Dtos
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}