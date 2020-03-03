using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF.Models;

namespace EF.Controllers
{
    public class EmpController : Controller
    {
        tranningEntities obj = new tranningEntities();
        // GET: Emp
        public ActionResult Index()
        {
            return View(obj.Employees.ToList());
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                obj.Employees.Add(employee);
                obj.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            return View(obj.Employees.Find(id));
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                obj.Entry(employee).State = EntityState.Modified;
                obj.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            return View(obj.Employees.Find(id));
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var q = obj.Employees.Find(id);
                obj.Entry(q).State = System.Data.Entity.EntityState.Deleted;
                obj.SaveChanges();
                return RedirectToAction("Employee");
            }
            catch
            {
                return View();
            }
        }
    }
}
