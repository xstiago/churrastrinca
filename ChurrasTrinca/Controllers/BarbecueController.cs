using AutoMapper;
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
                .OrderBy(o => o.Date);

            return View(allBarbecues);
        }

        //
        // GET: /Barbecue/Details/5
        public ActionResult Details(int id)
        {
            var barbecue = _barbecueDomain.GetById(id);
            return View(new BarbecueModel());
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
                var barcecue = Mapper.Map<Barbecue>(barbecueModel);

                _barbecueDomain.Save(barcecue);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Barbecue/Edit/5
        public ActionResult Edit(int id)
        {
            var barcecue = _barbecueDomain.GetById(id);
            return View(barcecue);
        }

        //
        // POST: /Barbecue/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BarbecueModel barbecueModel)
        {
            try
            {
                var barcecue = Mapper.Map<Barbecue>(barbecueModel);

                _barbecueDomain.Save(barcecue);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Barbecue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Barbecue/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
