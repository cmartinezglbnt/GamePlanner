namespace GamePlanner.Web.Data
{
    using Entities;

    public class MeetingRepository : GenericRepository<Meeting>, IMeetingRepository
    {
        public MeetingRepository(DataContext context) : base(context)
        {
        }
    }

}