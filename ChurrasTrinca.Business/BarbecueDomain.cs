using ChurrasTrinca.Business.Contracts;
using ChurrasTrinca.DataAccess.Contracts;
using ChurrasTrinca.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ChurrasTrinca.Business
{
    public class BarbecueDomain : IBarbecueDomain
    {
        private IBarbecueRepository _barbecueRepository;

        public BarbecueDomain(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public IList<Barbecue> Get()
        {
            return _barbecueRepository
                .Get(o => o.BarbecueID > 0)
                .ToList();
        }

        public Barbecue GetById(int id)
        {
            return _barbecueRepository
                .Get(o => o.BarbecueID == id)
                .FirstOrDefault();
        }

        public void Save(Barbecue barbercue)
        {
            var barbecue = this.GetById(barbercue.BarbecueID);

            if (barbercue == null)
            {
                _barbecueRepository.Add(barbercue);
            }
            else
            {
                //TODO Upade
            }
        }
    }
}
