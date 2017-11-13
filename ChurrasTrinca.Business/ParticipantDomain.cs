using ChurrasTrinca.Business.Contracts;
using ChurrasTrinca.DataAccess.Contracts;
using ChurrasTrinca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurrasTrinca.Business
{
    public class ParticipantDomain : IParticipantDomain
    {
        private IParticipantRepository _participantRepository;

        public ParticipantDomain(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }
        
        public IList<Participant> Get()
        {
            return _participantRepository.Get(o => o.ParticipantID > 0).ToList();
        }

        public Participant GetById(int id)
        {
            return _participantRepository
                .Get(o => o.ParticipantID == id)
                .FirstOrDefault();
        }

        public void Save(Participant participant)
        {
            var participantGet = this.GetById(participant.ParticipantID);

            if (participantGet == null)
            {
                _participantRepository.Add(participant);
            }
            else
            {
                //TODO Update
            }
        }
    }
}
