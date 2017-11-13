using ChurrasTrinca.DataAccess.Contracts;
using ChurrasTrinca.Entities;
using System.Data.Entity;

namespace ChurrasTrinca.DataAccess
{
    public class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
    {
        private readonly DbContext _dbContext;

        public ParticipantRepository(DbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
