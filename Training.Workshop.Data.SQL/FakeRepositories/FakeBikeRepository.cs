using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.SQL
{
    using System.Diagnostics.CodeAnalysis;

    public class FakeBikeRepository:IBikeRepository
    {
        /// <summary>
        /// Saves bike into repository
        /// </summary>
        /// <param name="user"></param>
        public void Save(Bike user)
        {
        }

        /// <summary>
        /// Deletes bikes by userID and bikes.mark
        /// </summary>
        /// <param name="mark">
        /// The mark.
        /// </param>
        /// <param name="ownerID">
        /// The owner ID.
        /// </param>
        public void Delete(string mark, int ownerID)
        {
        }



        /// <summary>
        /// Find and return's concrete bike if he exist in BD
        /// </summary>
        /// <param name="username"></param>
        public Bike Find(int bikeID)
        {
            // TODO
            // need realization
            return new Bike();
        }

        /// <summary>
        /// Update bike's condition to new condition
        /// </summary>
        /// <param name="manufacturer">
        /// The manufacturer.
        /// </param>
        /// <param name="mark">
        /// </param>
        /// <param name="ownerID">
        /// The owner ID.
        /// </param>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <param name="newcondition">
        /// The newcondition.
        /// </param>
        public void UpdateCondition(
            string manufacturer,
            string mark,
            int ownerid,
            string condition,
            string newcondition)
        {
            // TODO
            // need realization
        }

        /// <summary>
        /// return all bikes which belong to owner by owner name
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public List<Bike> Search(string owner)
        {
            // TODO
            // need realization
            return new List<Bike>();
        }

        /// <summary>
        /// Return all bikes
        /// </summary>
        /// <returns></returns>
        public List<Bike> RetrieveAllBikes()
        {
            // TODO
            // need realization
            return new List<Bike>();
        }
    }
}
