namespace GamePlanner.Web.Data
{
    using Entities;

    public class IdeaRepository : GenericRepository<Idea>, IIdeaRepository
    {
        public IdeaRepository(DataContext context) : base(context)
        {
        }
    }

}
