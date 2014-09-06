using Training.Workshop.Domain.Entities;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;
using System;


namespace Training.Workshop.Service
{
    public class BikeService : IBikeService
    {

        /// <summary>
        /// Create a new bike in the system
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public virtual Bike Create(string manufacturer, string mark, string ownername, int bikeyear, string conditionstate)
        {
            //if owner with ownername exist in database-add bike to database and return it,else return bike with empty fields.
            int ownerID = Data.Context.Current.RepositoryFactory.GetUserRepository().GetUserIDbyUsername(ownername);

            if (ownerID != 0)
            {

                var bike = new Bike
                {
                    Manufacturer = manufacturer,
                    Mark = mark,
                    OwnerID = ownerID,
                    BikeYear = new DateTime(bikeyear, 1, 1),
                    ConditionState = conditionstate
                };
                
                
                Data.Context.Current.RepositoryFactory.GetBikeRepository()
                  .Save(bike);
                return bike;
            }
            else return new Bike();
        }

        /// <summary>
        /// Delete existing bike from system
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        public virtual void Delete(string mark, int ownerID)
        {
            Data.Context.Current.RepositoryFactory.GetBikeRepository().
                Delete(mark, ownerID);
        }
        /// <summary>
        /// Search and return all bikes which belong to owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public virtual List<Bike> Findbikebyownername(string ownername)
        {
            return Data.Context.Current.RepositoryFactory.GetBikeRepository().
                Search(ownername);
        }
        /// <summary>
        /// Search and return all bikes
        /// </summary>
        /// <returns></returns>
        public virtual List<Bike> Search()
        {
            return Data.Context.Current.RepositoryFactory.GetBikeRepository().
                RetrieveAllBikes();
        }
        /// <summary>
        /// update any bike condition to good
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="ownerID"></param>
        /// <param name="condition"></param>
        public void UpdateCondition(string manufacturer, string mark, int ownerID, string condition, string newcondition)
        {
            Data.Context.Current.RepositoryFactory.GetBikeRepository().UpdateCondition(manufacturer, mark, ownerID, condition, newcondition);
        }
        /// <summary>
        /// retrieve bike from database by bikeID
        /// </summary>
        /// <param name="bikeid"></param>
        /// <returns></returns>
        public Bike Findbybikeid(int bikeid)
        {
            return Data.Context.Current.RepositoryFactory.GetBikeRepository().Find(bikeid);
        }

    }
}
