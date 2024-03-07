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
        /// <summary>
        /// Gets list of users from the server
        /// </summary>
        /// <returns>List of Users DTO</returns>
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
        /// <summary>
        /// Gets the user by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User DTO</returns>
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
        /// <summary>
        /// Adds user to the server 
        /// </summary>
        /// <param name="user">User model</param>
        /// <returns>Action result</returns>
        [HttpPost]
        public async Task<IHttpActionResult> AddUser(Models.Users user)
        {
            if (user == null) { return BadRequest(); }

            entities.Users.Add(user);
            await entities.SaveChangesAsync();
            return Ok("User was succesfully added");
        }
        /// <summary>
        /// Deletes user by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Action result</returns>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            Models.Users user = await entities.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            entities.Users.Remove(user);
            await entities.SaveChangesAsync();
            return Ok($"User: \"{user.FullName}\" was succesfully deleted");
        }
        /// <summary>
        /// Updates user's data
        /// </summary>
        /// <param name="user">User model</param>
        /// <returns>Action result</returns>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser(Models.Users user)
        {
            if (user == null) { return BadRequest(); };

            try
            {
                var foundUser = entities.Users.FirstOrDefault(b => b.Id == user.Id);

                if (foundUser == null)
                {
                    return NotFound();
                }

                // Обновление свойств существующей записи с использованием значений из переданного объекта user
                foundUser.FullName = user.FullName;
                foundUser.DateOfBirth = user.DateOfBirth;
                foundUser.Address = user.Address;
                foundUser.Email = user.Email;
                foundUser.Phone = user.Phone;

                await entities.SaveChangesAsync();

                return Ok("User was succesfully updated");
            }
            catch (Exception ex)
            {
                // Обработка ошибок при обновлении записи
                return InternalServerError(ex);
            }
        }
    }
}