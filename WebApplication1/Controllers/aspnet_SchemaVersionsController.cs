using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class aspnet_SchemaVersionsController : Controller
    {
        private ASPNETDBEntities db = new ASPNETDBEntities();

        // GET: aspnet_SchemaVersions
        public ActionResult Index()
        {
            return View(db.aspnet_SchemaVersions.ToList());
        }

        // GET: aspnet_SchemaVersions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnet_SchemaVersions aspnet_SchemaVersions = db.aspnet_SchemaVersions.Find(id);
            if (aspnet_SchemaVersions == null)
            {
                return HttpNotFound();
            }
            return View(aspnet_SchemaVersions);
        }

        // GET: aspnet_SchemaVersions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: aspnet_SchemaVersions/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Feature,CompatibleSchemaVersion,IsCurrentVersion")] aspnet_SchemaVersions aspnet_SchemaVersions)
        {
            if (ModelState.IsValid)
            {
                db.aspnet_SchemaVersions.Add(aspnet_SchemaVersions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspnet_SchemaVersions);
        }

        // GET: aspnet_SchemaVersions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnet_SchemaVersions aspnet_SchemaVersions = db.aspnet_SchemaVersions.Find(id);
            if (aspnet_SchemaVersions == null)
            {
                return HttpNotFound();
            }
            return View(aspnet_SchemaVersions);
        }

        // POST: aspnet_SchemaVersions/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Feature,CompatibleSchemaVersion,IsCurrentVersion")] aspnet_SchemaVersions aspnet_SchemaVersions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspnet_SchemaVersions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspnet_SchemaVersions);
        }

        // GET: aspnet_SchemaVersions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aspnet_SchemaVersions aspnet_SchemaVersions = db.aspnet_SchemaVersions.Find(id);
            if (aspnet_SchemaVersions == null)
            {
                return HttpNotFound();
            }
            return View(aspnet_SchemaVersions);
        }

        // POST: aspnet_SchemaVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            aspnet_SchemaVersions aspnet_SchemaVersions = db.aspnet_SchemaVersions.Find(id);
            db.aspnet_SchemaVersions.Remove(aspnet_SchemaVersions);
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
