namespace GamePlanner.Web.Data
{
    using Entities;

    public class TechnologyRepository : GenericRepository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(DataContext context) : base(context)
        {
        }
    }

}
