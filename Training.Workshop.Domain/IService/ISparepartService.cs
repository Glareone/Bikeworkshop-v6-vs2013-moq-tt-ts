using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

namespace Training.Workshop.Domain.Services
{
    public interface ISparepartService
    {
        /// <summary>
        /// Create new sparepart int the system
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        /// <param name="prise"></param>
        /// <returns></returns>
        Sparepart Create(string manufacturername, string sparepartname, string partnumber, int prise);
        /// <summary>
        /// Delete existing sparepart in system
        /// </summary>
        void Delete(string partnumber);
        /// <summary>
        /// Get sparepart by part number
        /// </summary>
        /// <param name="partnumber"></param>
        /// <returns></returns>
        List<Sparepart> GetSparepartbyPartsnumber(string partnumber);
        /// <summary>
        /// Get all spareparts by sparepart name
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <returns></returns>
        List<Sparepart> GetSparepartsbyName(string sparepartname);
        /// <summary>
        /// Get all spareparts by price
        /// </summary>
        /// <param name="minprice"></param>
        /// <param name="maxprice"></param>
        /// <returns></returns>
        List<Sparepart> GetSparepartsbyPrice(double minprice, double maxprice);
        /// <summary>
        /// Get all spareparts by manufacturer name
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        List<Sparepart> GetSparepartbyManufacturer(string manufacturername);
    }
}
