using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.SQL
{
    public class FakeSparepartRepository:ISparepartRepository
    {
        /// <summary>
        /// Saves sparepart into repository
        /// </summary>
        /// <param name="user"></param>
        public void Save(Sparepart user)
        {
            // TODO
            // need realization
        }

        /// <summary>
        /// Deletes sparepart by sparepartname and partnumber
        /// </summary>
        /// <param name="username"></param>
        public void Delete(string partnumber)
        {
            // TODO
            // need realization
        }

        /// <summary>
        /// Get list of spareparts by part number
        /// spareparts by different manufacturers
        /// </summary>
        /// <param name="username"></param>
        public List<Sparepart> GetSparepartbyPartnumber(string partnumber)
        {
            // TODO
            // need realization
            return new List<Sparepart>();
        }

        /// <summary>
        /// Get list of spareparts by sparepart name
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartsbyName(string sparepartname)
        {
            // TODO
            // need realization
            return new List<Sparepart>();
        }

        /// <summary>
        /// Get list of spareparts which includes in price parameters
        /// </summary>
        /// <param name="minprice"></param>
        /// <param name="maxprice"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartsbyPrice(double minprice, double maxprice)
        {
            // TODO
            // need realization
            return new List<Sparepart>();
        }

        /// <summary>
        /// Get all spareparts existing in workshop by manufacturer's name
        /// </summary>
        /// <param name="manufacturername"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartbyManufacturer(string manufacturername)
        {
            // TODO
            // need realization
            return new List<Sparepart>();
        }
    }
}
