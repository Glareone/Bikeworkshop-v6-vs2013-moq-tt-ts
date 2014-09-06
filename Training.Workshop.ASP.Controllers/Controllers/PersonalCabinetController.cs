using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Controllers
{
    public class PersonalCabinetController:IPersonalCabinetController
    {
        public List<Bike> SearchBikesbyOwnername(string owner)
        {
          return Bike.Findbikebyownername(owner);
        }
    }
}
