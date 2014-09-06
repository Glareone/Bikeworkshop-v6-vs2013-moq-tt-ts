using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Controllers.Interfaces
{
    public interface IPersonalCabinetController : IPageController
    {
        List<Bike> SearchBikesbyOwnername(string owner);
    }
}
