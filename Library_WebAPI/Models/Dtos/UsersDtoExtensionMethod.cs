using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library_WebAPI.Models.Dtos;


namespace Library_WebAPI.Models.Dtos
{
    public static class UsersDtoExtensionMethod
    {
        /// <summary>
        /// Get DTO from User model
        /// </summary>
        /// <param name="user">User model</param>
        /// <returns>User DTO</returns>
        public static Models.Dtos.Users GetUserDto(this Models.Users user)
        {
            return new Models.Dtos.Users()
            {
                Id = user.Id,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone
            };
        }
        /// <summary>
        /// Get User model from User DTO
        /// </summary>
        /// <param name="user">User DTO</param>
        /// <returns>User Model</returns>
        public static Models.Users GetUserFromDto(this Models.Dtos.Users user)
        {
            return new Models.Users()
            {
                Id = user.Id,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone
            };
        }
    }
}