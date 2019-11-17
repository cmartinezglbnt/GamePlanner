namespace GamePlanner.Web.Data
{
    using Entities;

    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(DataContext context) : base(context)
        {
        }
    }

}
