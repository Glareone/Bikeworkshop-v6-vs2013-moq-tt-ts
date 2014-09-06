using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Controllers.Interfaces
{
    public interface IAdminPanelController : IPageController
    {
        List<User> GetAllUsers();

        User AddNewUser(string username, string password, string[] role);

        void DeleteUser(string username);

        User UpdateUserPassword(string username, string password, string newpassword);

        User UpdateUserRole(string username, string password, string[] newroles);

        Bike AddNewBike(string manufacturer, string mark, int bikeyear, int ownerID, string condition);

        void UpdateExistingBike(string manufacturer, string mark, int ownerID, string condition, string newcondition);

        List<Bike> GetAllBikes();
    }
}
