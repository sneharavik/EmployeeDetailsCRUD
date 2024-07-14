using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeDetailsCRUD.Models;

namespace EmployeeDetailsCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private Employee_DBEntities1 db = new Employee_DBEntities1();
        private ToViewModel toviewmodel = new ToViewModel();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Tbl_Employee.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Employee tbl_Employee = db.Tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            EmployeeDataModel _obj = new EmployeeDataModel();
            return View(_obj);
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_ID,Emp_Code,Emp_Name,Address,Email_ID,Phone_No,Designation")] EmployeeDataModel tbl_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Employee.Add(toviewmodel.ToEmployee(tbl_Employee));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Employee tbl_Employee = db.Tbl_Employee.Find(id);
            EmployeeDataModel employeedatamodel = toviewmodel.ToEmployeeDataModel(tbl_Employee);
            if (employeedatamodel == null)
            {
                return HttpNotFound();
            }
            return View(employeedatamodel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_ID,Emp_Code,Emp_Name,Address,Email_ID,Phone_No,Designation")] EmployeeDataModel tbl_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toviewmodel.ToEmployee(tbl_Employee)).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Employee tbl_Employee = db.Tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Employee tbl_Employee = db.Tbl_Employee.Find(id);
            db.Tbl_Employee.Remove(tbl_Employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
