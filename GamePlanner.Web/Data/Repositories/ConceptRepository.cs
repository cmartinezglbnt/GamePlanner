namespace GamePlanner.Web.Data
{
    using Entities;

    public class ConceptRepository : GenericRepository<Concept>, IConceptRepository
    {
        public ConceptRepository(DataContext context) : base(context)
        {
        }
    }

}
