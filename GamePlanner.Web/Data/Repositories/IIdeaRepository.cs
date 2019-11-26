namespace GamePlanner.Web.Data
{
    using Entities;
    using System.Linq;

    public interface IIdeaRepository : IGenericRepository<Idea>
    {
        public IQueryable<Idea> GetAllIdeas();

        public IQueryable<Idea> GetAllIdeasByMeeting(int meetingId);
    }

}
