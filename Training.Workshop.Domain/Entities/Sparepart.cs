using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;

namespace Training.Workshop.Domain.Entities
{
    public class Sparepart : Entitybase
    {
        /// <summary>
        /// sparepart manufacturer
        /// </summary>
        public string SparepartManufacturer { get; set; }
        /// <summary>
        ///  sparepart's name
        /// </summary>
        public string SparepartName { get; set; }
        /// <summary>
        /// sparepart's japan's partnumber
        /// </summary>
        public string PartNumber { get; set; }
        /// <summary>
        /// sparepart's prise
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Create a new sparepart in database
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        /// <param name="prise"></param>
        /// <returns></returns>
        public static Sparepart Create(string manufacturername, string sparepartname, string partnumber, int prise)
        {
            return ServiceLocator.Resolve<ISparepartService>().
                Create(manufacturername, sparepartname, partnumber, prise);
        }
        /// <summary>
        /// Delete existing sparepart by partnumber
        /// </summary>
        /// <param name="partnumber"></param>
        public void Delete(string partnumber)
        {
            ServiceLocator.Resolve<ISparepartService>().Delete(partnumber);
        }
        /// <summary>
        /// Get spareparts by part number
        /// </summary>
        /// <param name="partnumber"></param>
        public List<Sparepart> GetSparepart(string partnumber)
        {
            return ServiceLocator.Resolve<ISparepartService>().
                GetSparepartbyPartsnumber(partnumber);
        }
        /// <summary>
        /// Get all spareparts by sparepart name
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <returns></returns>
        public List<Sparepart> GetSpareparts(string sparepartname)
        {
            return ServiceLocator.Resolve<ISparepartService>().
                GetSparepartsbyName(sparepartname);
        }
        /// <summary>
        /// take all parts by price
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartbyPrice(double minprice, double maxprice)
        {
            return ServiceLocator.Resolve<ISparepartService>().
                GetSparepartsbyPrice(minprice, maxprice);
        }
        /// <summary>
        /// Get all spareparts by manufacturer name
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartbyManufacturer(string manufacturer)
        {
            return ServiceLocator.Resolve<ISparepartService>().
                GetSparepartbyManufacturer(manufacturer);
        }

    }
}
