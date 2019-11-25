namespace GamePlanner.Web.Data
{
    using Entities;

    public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(DataContext context) : base(context)
        {
        }
    }

}
