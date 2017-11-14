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
    public class BarbecueController : Controller
    {
        private IBarbecueDomain _barbecueDomain;

        public BarbecueController(IBarbecueDomain barbecueDomain)
        {
            _barbecueDomain = barbecueDomain;
        }

        //
        // GET: /Barbecue/
        public ActionResult Index()
        {
            var allBarbecues = _barbecueDomain.Get()
                .OrderBy(o => o.Date)
                .Select(o => new BarbecueModel()
                {
                    BarbecueID = o.BarbecueID,
                    Comments = o.Comments,
                    Date = o.Date,
                    Description = o.Description,
                    TotalCollected = o.Participants.Sum(part => part.ContributionValue),
                    WithDrink = o.WithDrink,
                    WithoutDrink = o.WithoutDrink,
                    TotalParticipants = o.Participants.Count
                });

            return View(allBarbecues);
        }

        //
        // GET: /Barbecue/Details/5
        public ActionResult Details(int id)
        {
            var barbecue = _barbecueDomain.GetById(id);
            var barbecueModel = new BarbecueModel()
            {
                BarbecueID = barbecue.BarbecueID,
                Comments = barbecue.Comments,
                Date = barbecue.Date,
                Description = barbecue.Description,
                TotalCollected = barbecue.Participants.Sum(part => part.ContributionValue),
                WithDrink = barbecue.WithDrink,
                WithoutDrink = barbecue.WithoutDrink,
                AmountAlreadyPaid = barbecue.Participants.Sum(part => part.ContributionValue),
                TotalDrunker = barbecue.Participants.Where(part => part.WithDrink).Count(),
                TotalNotDrunker = barbecue.Participants.Where(part => part.WithDrink).Count(),
                ParticipantsNumber = barbecue.Participants.Count(),
                Participants = barbecue.Participants.Select(o => new ParticipantModel()
                {
                    Comments = o.Comments,
                    ContributionValue = o.ContributionValue,
                    IsPaid = o.IsPaid,
                    Name = o.Name,
                    ParticipantID = o.ParticipantID,
                    WithDrink = o.WithDrink
                }).ToList()
            };

            TempData["BarbecueId"] = barbecue.BarbecueID;

            return View(barbecueModel);
        }

        //
        // GET: /Barbecue/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Barbecue/Create
        [HttpPost]
        public ActionResult Create(BarbecueModel barbecueModel)
        {
            try
            {
                var barcecue = new Barbecue()
                {
                    Comments = barbecueModel.Comments,
                    Date = barbecueModel.Date,
                    Description = barbecueModel.Description,
                    WithDrink = barbecueModel.WithDrink,
                    WithoutDrink = barbecueModel.WithoutDrink
                };

                _barbecueDomain.Save(barcecue);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
