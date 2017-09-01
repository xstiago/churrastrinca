using ChurrasTrinca.DataAccess.Entities;
using ChurrasTrinca.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
