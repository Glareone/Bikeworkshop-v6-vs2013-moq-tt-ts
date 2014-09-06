using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Controllers.Interfaces
{
    public interface IUserPageController : IPageController
    {
        User AddUser(string username, string password, string[] roles);

        List<string> GetRolesbyUsername(string username);
    }
}

