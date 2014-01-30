using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetDatabases.Databases;
using AspNetDatabases.Models;
using System.Data;
using System.Data.Entity;

namespace AspNetDatabases.Controllers
{
    public class CdDbController : Controller
    {
        private CdDbContext DB = new CdDbContext();
        //
        // GET: /CdDb/

        public ActionResult Index()
        {
            return View(DB.cddb.ToList());
        }

        //
        // GET: /CdDb/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CdDb/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "ID")] CdDb cdToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            DB.cddb.Add(cdToCreate);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /CdDb/Edit/
        public ActionResult Edit(int id = 0)
        {
            CdDb item = DB.cddb.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }
        //
        // POST: /CdDb/Edit/ 
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(CdDb cddbToEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(cddbToEdit);
            }
            DB.Entry(cddbToEdit).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /CdDb/Delete/
        public ActionResult Delete(int id = 0)
        {
            CdDb item = DB.cddb.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }
        //
        // POST: /CdDb/Delete/ 
        [AcceptVerbs(HttpVerbs.Post), ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            CdDb item = DB.cddb.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            DB.cddb.Remove(item);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /CdDb/SearchIndex
        public ActionResult SearchIndex(string searchString)
        {
            var discs = from cd in DB.cddb
                        select cd;
            if (!String.IsNullOrEmpty(searchString))
            {
                discs = discs.Where(disc => disc.Title.Contains(searchString));
            }
            return View(discs);
        }

        // GET: /CdDb2/Details/5

        public ActionResult Details(int id = 0)
        {
            CdDb cddb = DB.cddb.Find(id);
            if (cddb == null)
            {
                return HttpNotFound();
            }
            return View(cddb);
        }
    }
}