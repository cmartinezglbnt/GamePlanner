namespace GamePlanner.Web.Data
{
    using Entities;

    public class ToolRepository : GenericRepository<Tool>, IToolRepository
    {
        public ToolRepository(DataContext context) : base(context)
        {
        }
    }

}
