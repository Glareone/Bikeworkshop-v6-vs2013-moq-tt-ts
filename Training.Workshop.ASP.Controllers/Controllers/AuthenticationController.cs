using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.Domain.Entities;


namespace Training.Workshop.ASP.Controllers
{
    public class AuthenticationController : IAuthenticationController
    {
        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User LogIn(string username, string password)
        {
          return  User.GetUser(username, password);
        }
    }
}
