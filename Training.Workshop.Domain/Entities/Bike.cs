using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Services;
using Training.Workshop.Service.ServiceLocator;

namespace Training.Workshop.Domain.Entities
{
    public class Bike : Entitybase
    {
        /// <summary>
        /// motocycle's manufacturer
        /// </summary>
        public string Manufacturer { get; set; }


        /// <summary>
        /// mark of motocycle
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// moto's owner
        /// </summary>
        public int OwnerID { get; set; }

        /// <summary>
        /// moto's year of creating
        /// </summary>
        public DateTime BikeYear { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ConditionState { get; set; }
        /// <summary>
        /// override Equals method because Bike type is reference type
        /// used in .Equal(bike) method and listofbikes.Contains(bike)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = (Bike)obj;

            if (other != null)
            {
                if (Manufacturer == other.Manufacturer && Mark == other.Mark &&
                    OwnerID == other.OwnerID && BikeYear == other.BikeYear &&
                    ConditionState == other.ConditionState)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// override GetHashCode method because Bike Equal is overriding too
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}_{1}_{2}_{3}_{4}", Manufacturer, Mark, BikeYear.ToString(), OwnerID.ToString(), ConditionState).GetHashCode();
        }


        /// <summary>
        /// Add new Bike with all data. Uses this function by admin and owner
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Bike Create(string manufacturer, string mark, string ownername, int year, string conditionstate)
        {
            return ServiceLocator.Resolve<IBikeService>().Create(manufacturer, mark, ownername, year, conditionstate);
        }
        /// <summary>
        /// this func deletes all bike by mark and owner,this function used only by admins
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        public static void Delete(string mark, int ownerID)
        {
            ServiceLocator.Resolve<IBikeService>().Delete(mark, ownerID);
            //Context.Current.BikeService.Delete(mark, owner);
        }
        /// <summary>
        /// return list of bikes which belong by owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static List<Bike> Findbikebyownername(string owner)
        {
            return ServiceLocator.Resolve<IBikeService>().Findbikebyownername(owner);
        }
        /// <summary>
        /// return all bikes
        /// </summary>
        /// <returns></returns>
        public static List<Bike> Search()
        {
            return ServiceLocator.Resolve<IBikeService>().Search();
        }
        /// <summary>
        /// Update bike condition
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="ownerID"></param>
        /// <param name="condition"></param>
        public static void UpdateCondition(string manufacturer, string mark, int ownerID, string condition, string newcondition)
        {
            ServiceLocator.Resolve<IBikeService>().UpdateCondition(manufacturer, mark, ownerID, condition, newcondition);
        }

        public static Bike Findbikebybikeid(int bikeID)
        {
            return ServiceLocator.Resolve<IBikeService>().Findbybikeid(bikeID);
        }
    }
}
