using Training.Workshop.Domain.Services;
using Training.Workshop.Service.ServiceLocator;

namespace Training.Workshop.Domain
{
    public sealed class Context
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Context"/> class
        /// </summary>
        private Context()
        {
        }

        /// <summary>
        /// Gets current execution context
        /// </summary>
        public static Context Current = new Context();

        /// <summary>
        /// Gets current <see cref="IUserService"/>
        /// </summary>
        public IUserService UserService { get; set; }
        public IBikeService BikeService { get; set; }
        public ISparepartService SparepartService { get; set; }
    }
}