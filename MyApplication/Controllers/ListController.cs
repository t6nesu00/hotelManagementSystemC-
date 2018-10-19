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
        private CustomerEntities1 _db = new CustomerEntities1();
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
            var listToEdit = (from m in _db.Customers
                              where m.CusotmerId == id
                              select m).First();
            return View(listToEdit);
        }

        // POST: List/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer listToEdit)
        {
            var originalCustomer = (from m in _db.Customers
                                    where m.CusotmerId == listToEdit.CusotmerId
                                    select m).First();

            if (!ModelState.IsValid)
                return View(originalCustomer);

            _db.Entry(originalCustomer).CurrentValues.SetValues(listToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        // GET: List/Delete/5
        public ActionResult Delete(int id)
        {
            var listToDelete = (from m in _db.Customers
                              where m.CusotmerId == id
                              select m).First();
            return View(listToDelete);
            
        }

        // POST: List/Delete/5
        [HttpPost]
        public ActionResult Delete(Customer listToDelete, int id = 0)
        {
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
