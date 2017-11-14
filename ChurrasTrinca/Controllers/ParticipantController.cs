using ChurrasTrinca.Business.Contracts;
using ChurrasTrinca.Entities;
using ChurrasTrinca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChurrasTrinca.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly IParticipantDomain _participantDomain;

        public ParticipantController(IParticipantDomain participantDomain)
        {
            _participantDomain = participantDomain;
        }
        
        //
        // GET: /Participant/
        public ActionResult Index()
        {
            var allParticipants = _participantDomain.Get()
                .OrderBy(o => o.Name)
                .Select(o => new ParticipantModel()
                {
                    Comments = o.Comments,
                    ContributionValue = o.ContributionValue,
                    IsPaid = o.IsPaid,
                    Name = o.Name,
                    ParticipantID = o.ParticipantID,
                    WithDrink = o.WithDrink
                });

            return View(allParticipants);
        }

        //
        // GET: /Participant/Details/5
        public ActionResult Details(int id)
        {
            var participant = _participantDomain.GetById(id);
            var participantModel = new ParticipantModel()
            {
                Comments = participant.Comments,
                ContributionValue = participant.ContributionValue,
                IsPaid = participant.IsPaid,
                Name = participant.Name,
                ParticipantID = participant.ParticipantID,
                WithDrink = participant.WithDrink
            };

            return View(participantModel);
        }

        //
        // GET: /Participant/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Participant/Create
        [HttpPost]
        public ActionResult Create(ParticipantModel participantModel)
        {
            try
            {
                var participant = new Participant()
                {
                    Comments = participantModel.Comments,
                    ContributionValue = participantModel.ContributionValue,
                    IsPaid = participantModel.IsPaid,
                    Name = participantModel.Name,
                    WithDrink = participantModel.WithDrink,
                    BarbecueID = Convert.ToInt32(TempData["BarbecueId"])
                };

                _participantDomain.Save(participant);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
