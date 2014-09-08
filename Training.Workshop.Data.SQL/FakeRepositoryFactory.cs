using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Workshop.Data.SQL
{
    /// <summary>
    /// Fake repository factory for testing
    /// </summary>
    public class FakeRepositoryFactory : IRepositoryFactory
    {
        /// <summary>
        /// Fake repository factory for fake user 
        /// repository using based on T4
        /// </summary>
        /// <returns>
        /// returns fake user repository
        /// </returns>
        public IUserRepository GetUserRepository()
        {
            return new FakeUserRepository();
        }

        /// <summary>
        /// Fake repository factory for fake bike 
        /// repository using based on T4
        /// </summary>
        /// <returns>
        /// returns fake bike repository
        /// </returns>
        public IBikeRepository GetBikeRepository()
        {
            return new FakeBikeRepository();
        }

        /// <summary>
        /// Fake repository factory for Fake Spare part 
        /// repository using based on T4
        /// </summary>
        /// <returns>
        /// returns fake Spare part repository
        /// </returns>
        public ISparepartRepository GetSparepartRepository()
        {
            return new FakeSparepartRepository();
        }
    }
}
