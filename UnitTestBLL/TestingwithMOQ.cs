using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using Training.Workshop.Service;
using Training.Workshop.UnitOfWork;
using Training.Workshop.Domain.Entities;
using Training.Workshop.Data;

namespace UnitTestBLL
{
    [TestClass]
    public class TestingwithMOQ
    {
        [TestMethod]
        public void TestMethod1()
        {
            string username = "testinguser";

            var listofpermission = new List<string> { "ReadAll", "WriteAll", "DeleteAll" };

            var role1 = new Role { Name = "administrator", Permissions = listofpermission };

            var roles = new List<Role> { role1 };

            string[] repositorytestrole = new string[] { "administrator" };

            string repositorytestusername = "testuser";

            string repositorytestpassword = "testpassword";

            int value = 1;

            string repositorytestmark = "CBR600RR";

            string repositorytestmanufacturer = "HONDA";

            var repositorytestbikeyear = new DateTime(2000, 1, 1);

            string repositorytestcondition = "normal_for_test";


            //configuring userrepository mock
            var userrepository = new Mock<IUserRepository>();

            userrepository.Setup(m => m.GetUser(repositorytestusername, repositorytestpassword)).Returns(new User { Username = repositorytestusername, Roles = roles });

            userrepository.Setup(m => m.RetrieveAllUsers()).Returns(new List<User> { new User { Username = repositorytestusername, Roles = roles } });

            userrepository.Setup(m => m.GetAllUsers()).Returns(new List<User> { new User { Username = repositorytestusername, Roles = roles } });

            userrepository.Setup(m => m.GetUserIDbyUsername(username)).Returns(value);

            userrepository.Setup(m => m.GetUserIDbyUsername(repositorytestusername)).Returns(2);

            userrepository.Setup(m => m.SaveNewUser(repositorytestusername, repositorytestpassword, repositorytestrole)).Returns(true);

            //configuring bikerepository mock
            var bikerepository = new Mock<IBikeRepository>();

            var currentbike = new Bike
            {
                Manufacturer = repositorytestmanufacturer,
                Mark = repositorytestmark,
                BikeYear = repositorytestbikeyear,
                ConditionState = repositorytestcondition,
                OwnerID = 1

            };

            bikerepository.Setup(m => m.RetrieveAllBikes()).Returns(new List<Bike> { currentbike });

            bikerepository.Setup(m => m.Search(repositorytestusername)).Returns(new List<Bike> { currentbike });

            //configuring repository factory mock object in all repositories
            var repositoryfactory = new Mock<IRepositoryFactory>();

            repositoryfactory.Setup(m => m.GetUserRepository()).Returns(userrepository.Object);

            repositoryfactory.Setup(m => m.GetBikeRepository()).Returns(bikerepository.Object);

            //Start Domain and Services testing with Repository isolation.
            ServiceLocator.RegisterService<IUserService>(typeof(UserService));

            //Service->RepositoryFactory->Mock Object
            Training.Workshop.Data.Context.Current.RepositoryFactory = repositoryfactory.Object;

            var user = User.Create(repositorytestusername, repositorytestpassword, repositorytestrole);

            Assert.IsTrue(user.Username == repositorytestusername);

            Assert.IsTrue(user.Roles == roles);

            //Stop userrepository testing
            //Start bikerepository testing
            ServiceLocator.RegisterService<IBikeService>(typeof(BikeService));


            var bike1 = Bike.Create(repositorytestmanufacturer, repositorytestmark, repositorytestusername, value, repositorytestcondition);

            Assert.IsTrue
                (
                bike1.Manufacturer == repositorytestmanufacturer &&
                bike1.Mark == repositorytestmark &&
                bike1.OwnerID == 2 &&
                bike1.ConditionState == repositorytestcondition
                );

            var bike2 = Bike.Create(repositorytestmark, repositorytestmanufacturer, repositorytestusername, value, repositorytestcondition);

            Assert.IsFalse
               (
               bike2.Manufacturer == repositorytestmanufacturer &&
               bike2.Mark == repositorytestmark &&
               bike2.OwnerID == value &&
               bike2.ConditionState == repositorytestcondition
               );
            //Stop bikerepository testing

            //Domain testing with service mock.
            //cunfiguring services
            var iuserservice = new Mock<IUserService>();

            string newusername = "testuser";
            iuserservice.Setup(m => m.GetUser(newusername, newusername)).Returns(new User { Username = newusername, Roles = roles });

            iuserservice.Setup(m => m.Create("newuser", "newuser", repositorytestrole)).Returns(new User { Username = "newuser", Roles = roles });

            iuserservice.Setup(m => m.Create("newuser2", "newuser2", repositorytestrole)).Returns(new User { Username = "newuser", Roles = roles });
            //right choise
            iuserservice.Setup(m => m.GetUser(newusername, newusername)).Returns(new User { Username = "newuser", Roles = roles });
            //right
            userrepository.Setup(m => m.GetUser(newusername, newusername)).Returns(new User { Username = newusername, Roles = roles });

            userrepository.Setup(m => m.SaveNewUser("newuser", "newuser", repositorytestrole)).Returns(false);

            userrepository.Setup(m => m.SaveNewUser(newusername, newusername, repositorytestrole)).Returns(true);

            //Start Domain testing
            //uncorrect SaveNewUser(username,password,roles),uncorrect data in User
            var newuser1 = User.Create("newuser", "newuser", repositorytestrole);



            Assert.IsFalse
                (
                newuser1.Username == newusername &&
                newuser1.Roles == roles
                );

            //correct SaveNewUser(), correct data in User

            var newuser2 = User.Create(newusername, newusername, repositorytestrole);

            userrepository.Setup(m => m.SaveNewUser(newusername, newusername, repositorytestrole)).Returns(true);

            Assert.IsTrue
                (
                newuser2.Username == newusername &&
                newuser2.Roles == roles
                );


            //uncorrect SaveNewUser(), correct data in User
            var newuser3 = User.Create("newuser2", "newuser2", repositorytestrole);

            Assert.IsFalse
              (
              newuser3.Username == newusername &&
              newuser3.Roles == roles
              );

            //Stop Domain testing
        }
    }
}
