using ChurrasTrinca.DataAccess.Contracts;
using ChurrasTrinca.Entities;
using System.Data.Entity;

namespace ChurrasTrinca.DataAccess
{
    public class BarbecueRepository : BaseRepository<Barbecue>, IBarbecueRepository
    {
        private readonly DbContext _dbContext;

        public BarbecueRepository(DbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
