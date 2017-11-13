using ChurrasTrinca.Entities;
using System.Collections.Generic;

namespace ChurrasTrinca.Business.Contracts
{
    public interface IParticipantDomain
    {
        IList<Participant> Get();
        Participant GetById(int id);
        void Save(Participant participant);
    }
}
