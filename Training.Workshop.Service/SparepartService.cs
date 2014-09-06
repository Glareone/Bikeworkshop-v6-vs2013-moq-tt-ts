using Training.Workshop.Domain.Entities;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;



namespace Training.Workshop.Service
{
    public class SparepartService : ISparepartService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public virtual Sparepart Create(string manufacturername, string sparepartname, string partnumber, int price)
        {
            var sparepart = new Sparepart
            {
                SparepartManufacturer = manufacturername,
                SparepartName = sparepartname,
                PartNumber = partnumber,
                Price = price
            };
            Data.Context.Current.RepositoryFactory.GetSparepartRepository()
              .Save(sparepart);
            return sparepart;
        }
        /// <summary>
        /// Delete concrete sparepart by partnumber
        /// </summary>
        /// <param name="partnumber"></param>
        public virtual void Delete(string partnumber)
        {
            Data.Context.Current.RepositoryFactory.GetSparepartRepository()
                    .Delete(partnumber);
        }
        /// <summary>
        /// Get sparepart by partnumber
        /// </summary>
        /// <param name="partnumber"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartbyPartsnumber(string partnumber)
        {
            return Data.Context.Current.RepositoryFactory.GetSparepartRepository()
                     .GetSparepartbyPartnumber(partnumber);
        }
        /// <summary>
        /// Get list of spareparts by sparepart name
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartsbyName(string sparepartname)
        {
            return Data.Context.Current.RepositoryFactory.GetSparepartRepository()
                    .GetSparepartsbyName(sparepartname);
        }
        /// <summary>
        /// Get list of spareparts by price
        /// </summary>
        /// <param name="minprice"></param>
        /// <param name="maxprice"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartsbyPrice(double minprice, double maxprice)
        {
            return Data.Context.Current.RepositoryFactory.GetSparepartRepository()
                    .GetSparepartsbyPrice(minprice, maxprice);
        }
        /// <summary>
        /// Get list of sparepart by manufacturer name
        /// </summary>
        /// <param name="manufacturername"></param>
        /// <returns></returns>
        public List<Sparepart> GetSparepartbyManufacturer(string manufacturername)
        {
            return Data.Context.Current.RepositoryFactory.GetSparepartRepository()
                    .GetSparepartbyManufacturer(manufacturername);
        }
    }
}
