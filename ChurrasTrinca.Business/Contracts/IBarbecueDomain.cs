using ChurrasTrinca.Entities;
using System.Collections.Generic;

namespace ChurrasTrinca.Business.Contracts
{
    public interface IBarbecueDomain
    {
        IList<Barbecue> Get();
        Barbecue GetById(int id);
        void Save(Barbecue barbercue);
    }
}
