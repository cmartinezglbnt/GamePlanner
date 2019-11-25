namespace GamePlanner.Web.Data
{
    using Entities;

    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(DataContext context) : base(context)
        {
        }
    }

}