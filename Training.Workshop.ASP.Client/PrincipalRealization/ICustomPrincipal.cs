using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.ASP.Client.PrincipalRealization
{
    public interface ICustomPrincipal: System.Security.Principal.IPrincipal
    {
        string Username { get; set; }
    }
}
