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
        //
        // GET: /Barbecue/
        public ActionResult Index()
        {
            return View(new List<BarbecueModel>());
        }

        //
        // GET: /Barbecue/Details/5
        public ActionResult Details(int id)
        {
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

        //
        // GET: /Barbecue/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Barbecue/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
