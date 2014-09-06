using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Workshop.Data;
using Training.Workshop.UnitOfWork;
using Training.Workshop.Domain.Entities;


namespace UnitTestBLL
{
    [TestClass]
    public class BikeRepositoryTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Configuration of Database
            //Work with SQL Database,if need work with file database need to comment Factory;
            Training.Workshop.Data.Context.Current.RepositoryFactory = new Training.Workshop.Data.SQL.RepositoryFactory();

            Training.Workshop.UnitOfWork.Context.Current.UnitOfWorkFactory = new Training.Workshop.Data.SQL.SQLSystemUnitOfWork.SQLSystemDatabaseUnitofWorkFactory();

            //existing user who have moto
            var existinguserwithmoto = "glareone";

            var existinguserwithoutmoto = "HOFMYVBPLVTUVLLBDYBR";

            var notexistinguser = "XXX";

            //Check bike search by username
            List<Bike> listofbikes = Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetBikeRepository().Search(existinguserwithmoto);

            Assert.IsTrue(listofbikes.Count != 0, "user had bikes,but listofbikes are empty");
            //Check bike search by username
            listofbikes = Training.Workshop.Data.Context.Current.
               RepositoryFactory.GetBikeRepository().Search(existinguserwithoutmoto);

            Assert.IsTrue(listofbikes.Count == 0, "user hasn't any bikes,but something wrong");

            listofbikes = Training.Workshop.Data.Context.Current.
              RepositoryFactory.GetBikeRepository().Search(notexistinguser);

            Assert.IsTrue(listofbikes.Count == 0, "user are not exist,but something wrong");


            //Check Retrieve all bikes and bikes by users.

            List<Bike> listofallbikes = Training.Workshop.Data.Context.Current.
              RepositoryFactory.GetBikeRepository().RetrieveAllBikes();

            //TODO
            //Check ALL bikes by userID

            //check Save(Bike bike) method
            var randomel = new Random();

            var bikeyear = new DateTime(randomel.Next(1985, 2013), randomel.Next(1, 12), randomel.Next(1, 25));

            string[] newManufacturer = new string[] { "Honda", "Suzuki", "Yamaha", "Ducatti", "Kawasaki", "Aprilia", "BMW", "MVAgusta" };

            string[] newMark = new string[] { "CBR600", "CB500", "Vulcan1300", "Intruder1700", "Hayabusa", "Bandit650", "Bandit1200", "VFR800", "VTR1000" };

            string[] newconditionstate = new string[] { "good", "bad", "oilflush", "enginebroke", "lossed", "paint need", "valves adjustment", "carburetors cleaning", "technical service" };

            //take combination
            //do that for checking Delete(string mark,int ownerid) method
            string newcurrentmark = newMark[randomel.Next(0, 8)];

            int newcurrentuserID = randomel.Next(12, 40);

            string newcurrentmanufacturer = newManufacturer[randomel.Next(0, 7)];

            string newcondition = newconditionstate[randomel.Next(0, 8)];

            var newbike = new Bike
            {
                Manufacturer = newcurrentmanufacturer,
                Mark = newcurrentmark,
                OwnerID = newcurrentuserID,
                BikeYear = bikeyear,
                ConditionState = newcondition
            };

            Training.Workshop.Data.Context.Current.RepositoryFactory.GetBikeRepository().
                Save(newbike);
            //Check that bike Save method works right
            listofbikes = Training.Workshop.Data.Context.Current.RepositoryFactory.GetBikeRepository().
                RetrieveAllBikes();

            CollectionAssert.Contains(listofbikes, newbike, "listofbikes doesn't contain creating bike");

            //check Update method works right
            Training.Workshop.Data.Context.Current.RepositoryFactory.GetBikeRepository().
                UpdateCondition(newcurrentmanufacturer, newcurrentmark, newcurrentuserID, newcondition, "GOOD!TEST!");

            //search bike and check new condition
            listofbikes = Training.Workshop.Data.Context.Current.RepositoryFactory.GetBikeRepository().
                RetrieveAllBikes();

            var newbikeforcheckcondition = new Bike
            {
                Manufacturer = newcurrentmanufacturer,
                Mark = newcurrentmark,
                OwnerID = newcurrentuserID,
                BikeYear = bikeyear,
                ConditionState = "GOOD!TEST!"
            };

            Assert.IsTrue(listofbikes.Contains(newbikeforcheckcondition));

            //check that Delete method works right
            Training.Workshop.Data.Context.Current.RepositoryFactory.GetBikeRepository().
                Delete(newcurrentmark, newcurrentuserID);

            listofbikes = Training.Workshop.Data.Context.Current.RepositoryFactory.GetBikeRepository().
                RetrieveAllBikes();

            CollectionAssert.DoesNotContain(listofallbikes, newbike, "listofbikes contain bike,error");
        }
    }
}
