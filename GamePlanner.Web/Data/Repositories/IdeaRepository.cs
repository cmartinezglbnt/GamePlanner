namespace GamePlanner.Web.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class IdeaRepository : GenericRepository<Idea>, IIdeaRepository
    {
        private readonly DataContext context;

        public IdeaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Idea> GetAllIdeas()
        {
            return this.context.Idea
                .Include(v => v.Gender)
                .Include(v => v.Public)
                .OrderByDescending(v => v.RegistrationDate);
        }
    }

}
