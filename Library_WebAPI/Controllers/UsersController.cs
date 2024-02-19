using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Library_WebAPI.Models;
using Library_WebAPI.Models.Dtos;

namespace Library_WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        LibraryEntities entities = new LibraryEntities();
        // GET: Users
        [HttpGet]
        public IQueryable<Models.Dtos.Users> GetUsers()
        {
            var users = entities.Users.Select(u => new Models.Dtos.Users()
            {
                Id = u.Id,
                FullName = u.FullName,
                DateOfBirth = u.DateOfBirth,
                Address = u.Address,
                Email = u.Email,
                Phone = u.Phone,
            } );

            return users;
        }

        [ResponseType(typeof(Models.Dtos.Users))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            Models.Users user = await entities.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            Models.Dtos.Users userDto = user.GetUserDto();

            return Ok(userDto);
        }

        // POST:
        [HttpPost]
        public async Task<IHttpActionResult> AddUser(Models.Users user)
        {
            if (user == null) { return BadRequest(); }

            entities.Users.Add(user);
            await entities.SaveChangesAsync();
            return Ok("User was succesfully added");
        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdateUser(Models.Dtos.Users user)
        {
            if (user == null) { return BadRequest(); };

            Models.Users foundUser = await entities.Users.FindAsync(user.Id);
            foundUser = user.GetUserFromDto();
            
            if (foundUser == null) { throw new Exception($"User with id = {user.Id} not found"); }; 
            
            await entities.SaveChangesAsync();
            return Ok(foundUser);
        }
    }
}