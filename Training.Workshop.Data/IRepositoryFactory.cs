namespace Training.Workshop.Data
{
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Gets user repository
        /// </summary>
        /// <returns></returns>
        IUserRepository GetUserRepository();

        IBikeRepository GetBikeRepository();

        ISparepartRepository GetSparepartRepository();
    }
}