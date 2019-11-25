namespace GamePlanner.Web.Data
{
    using Entities;

    public class GamePlayRepository : GenericRepository<GamePlay>, IGamePlayRepository
    {
        public GamePlayRepository(DataContext context) : base(context)
        {
        }
    }

}

