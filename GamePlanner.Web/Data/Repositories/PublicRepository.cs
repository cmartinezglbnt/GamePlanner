namespace GamePlanner.Web.Data
{
    using Entities;

    public class PublicRepository : GenericRepository<Public>, IPublicRepository
    {
        public PublicRepository(DataContext context) : base(context)
        {
        }
    }

}
