namespace GamePlanner.Web.Data
{
    using Entities;

    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(DataContext context) : base(context)
        {
        }
    }

}

