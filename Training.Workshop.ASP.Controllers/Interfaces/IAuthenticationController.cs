using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Controllers.Interfaces
{
    public interface IAuthenticationController : IPageController
    {
        User LogIn(string username, string password);
    }
}
