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
        //
        // GET: /Participant/
        public ActionResult Index()
        {
            return View(new List<ParticipantModel>());
        }

        //
        // GET: /Participant/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
