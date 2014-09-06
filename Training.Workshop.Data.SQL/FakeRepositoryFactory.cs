using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Workshop.Data.SQL
{
    public class FakeRepositoryFactory :IRepositoryFactory
    {
        /// <summary>
        /// Fake repository factory for fake user 
        /// repository using based on T4
        /// </summary>
        /// <returns></returns>
        public IUserRepository GetUserRepository()
        {
            //TODO
            //rework with FakeUserRepository
            return new UserRepository();
        }
        /// <summary>
        /// Fake repository factory for fake bike 
        /// repository using based on T4
        /// </summary>
        /// <returns></returns>
        public IBikeRepository GetBikeRepository()
        {
            //TODO
            //rework with FakeBikeRepository
            return new BikeRepository();
        }
        /// <summary>
        /// Fake repository factory for Fake sparepart 
        /// repository using based on T4
        /// </summary>
        /// <returns></returns>
        public ISparepartRepository GetSparepartRepository()
        {
            //TODO
            //rework with FakeSparepartRepository
            return new SparepartRepository();
        }
    }
}
