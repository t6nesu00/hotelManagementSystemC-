using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    public class ListController : Controller
    {
        private CustomerEntities _db = new CustomerEntities();
        // GET: List
        public ActionResult Index()
        {
            return View(_db.Customers.ToList());
        }

        // GET: List/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: List/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: List/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Customer listToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Customers.Add(listToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: List/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: List/Edit/5
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

        // GET: List/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: List/Delete/5
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
