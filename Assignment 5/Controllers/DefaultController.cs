using Assignment_5.Models;
using Assignment_5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment_5.Controllers
{
    public class DefaultController : Controller
    {
        ItemRepository repo = new ItemRepository();

        // GET: Default
        public ActionResult Index()
        {
            return View(repo.GetAllItems());
        }

        //

        [HttpPost]
        public ActionResult Index(string Search, string SearchByIDChecked)
        {
            IEnumerable<StockItem> item = null;
            if (SearchByIDChecked != null)
            {
                int s = 0; 
                s = int.Parse(Search);
                item = repo.GetItemsByID(s);
            }
            else { 

                item = repo.GetItemByNameOrPrice(Search);
            }
            return View(item);
        }


        public ActionResult Details(int ID)
        {
            return View(repo.GetItemByID(ID));
        }

        

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem item = repo.GetItemByID(id);
            if (item == null) {
                return HttpNotFound();
            }
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StockItem item) {

            if (ModelState.IsValid)
            {
                repo.Edit(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockItem item) {
            repo.Create(item);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /* book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }*/
            return View(repo.GetItemByID(id));
        }
        /*public ActionResult Remove(int ID)
        {
            
            return View(repo.GetItemByID(ID));

        }*/

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockItem item = repo.GetItemByID(id);
            repo.Remove(item);
            return RedirectToAction("Index");
        }


        public StockItem item { get; set; }

        
        public ActionResult SearchItemByName(string Name = "")
        {
            IEnumerable<StockItem> item = repo.GetItemByNameOrPrice(Name);
            return View(item);

        }

        
    }
}