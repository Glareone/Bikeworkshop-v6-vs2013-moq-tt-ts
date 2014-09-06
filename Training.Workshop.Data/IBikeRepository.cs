using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

namespace Training.Workshop.Data
{
    public interface IBikeRepository
    {
        /// <summary>
        /// Saves bike into repository
        /// </summary>
        /// <param name="user"></param>
        void Save(Bike user);

        /// <summary>
        /// Deletes bikes by userID and bikes.mark
        /// </summary>
        /// <param name="username"></param>
        /// TODO
        /// May be need returns bool
        void Delete(string mark, int ownerID);



        /// <summary>
        /// Find and return's concrete bike if he exist in BD
        /// </summary>
        /// <param name="username"></param>
        Bike Find(int bikeID);

        /// <summary>
        /// Update bike's condition to new condition
        /// </summary>
        /// <param name="username"></param>
        void UpdateCondition(string manufacturer, string mark, int ownerID, string condition, string newcondition);
        /// <summary>
        /// return all bikes which belong to owner by owner name
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        List<Bike> Search(string owner);
        /// <summary>
        /// Return all bikes
        /// </summary>
        /// <returns></returns>
        List<Bike> RetrieveAllBikes();
    }
}
