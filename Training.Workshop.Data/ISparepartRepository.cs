using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

namespace Training.Workshop.Data
{
    public interface ISparepartRepository
    {
        /// <summary>
        /// Saves sparepart into repository
        /// </summary>
        /// <param name="user"></param>
        void Save(Sparepart user);
        /// <summary>
        /// Deletes sparepart by sparepartname and partnumber
        /// </summary>
        /// <param name="username"></param>
        /// TODO
        /// May be need returns bool
        void Delete(string partnumber);
        /// <summary>
        /// Get sparepart by part number
        /// </summary>
        /// <param name="username"></param>
        List<Sparepart> GetSparepartbyPartnumber(string partnumber);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <returns></returns>
        List<Sparepart> GetSparepartsbyName(string sparepartname);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="minprice"></param>
        /// <param name="maxprice"></param>
        /// <returns></returns>
        List<Sparepart> GetSparepartsbyPrice(double minprice, double maxprice);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manufacturername"></param>
        /// <returns></returns>
        List<Sparepart> GetSparepartbyManufacturer(string manufacturername);
    }
}
