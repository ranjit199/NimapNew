using Project_ProductMaster.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_ProductMaster.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        ServiceContext db = new ServiceContext();

        public ActionResult Category(Category obj)
        {
            if (obj != null)

                return View(obj);
            else
                return View();
            
        }
        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                var strItem = Convert.ToString(model.CategoryId);
                Category obj = new Category();
                obj.CategoryId = model.CategoryId;
                obj.CategoryName = model.CategoryName;

                db.Categories.AddOrUpdate(obj);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Categorylist");
           // return View("Category");
        }
        public ActionResult Categorylist()
        {
            var res = db.Categories.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var strItem = Convert.ToString(id);
            var res = db.Categories.Where(x => x.CategoryId == strItem).First();
            db.Categories.Remove(res);
            db.SaveChanges();
            var list = db.Categories.ToList();
            return View("Categorylist",list);
        }

    }
}