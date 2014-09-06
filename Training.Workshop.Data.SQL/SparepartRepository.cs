using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.SQL
{
    public class SparepartRepository : ISparepartRepository
    {
        /// <summary>
        /// Save New sparepart to SQL Database
        /// </summary>
        /// <param name="sparepart"></param>
        public void Save(Sparepart sparepart)
        {
            //check if
        }

        /// <summary>
        /// Delete all existing spareparts from SQL database by partnumber
        /// </summary>
        /// <param name="partnumber"></param>
        public void Delete(string partnumber)
        {
            //TODO
            //Need realisation
        }
        /// <summary>
        /// Update existing sparepart in SQL database
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        public List<Sparepart> GetSparepartbyPartnumber(string partnumber)
        {
            //TODO
            //Need realisation
            return new List<Sparepart>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartsbyName(string sparepartname)
        {
            //TODO
            //Need realization
            return new List<Sparepart>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="minprice"></param>
        /// <param name="maxprice"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartsbyPrice(double minprice, double maxprice)
        {
            //TODO
            //Need realization
            return new List<Sparepart>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manufacturername"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartbyManufacturer(string manufacturername)
        {
            //TODO
            //Need realization
            return new List<Sparepart>();
        }

    }

}
