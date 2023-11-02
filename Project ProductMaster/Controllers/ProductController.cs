using Project_ProductMaster.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Configuration;

namespace Project_ProductMaster.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ServiceContext db1 = new ServiceContext();
        public ActionResult Index(int page)
        {


            return RedirectToAction("Productlist",new { page= page });

        }

        public ActionResult Product(Product obj)
        {

            var CategoryList = db1.Categories.ToList();
            ViewBag.CategoryTbl = new SelectList(CategoryList, "CategoryId", "CategoryName");

            if (obj != null)

                return View(obj);
            else
                return View();


        }
        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            
            if (ModelState.IsValid)
            {
                var strItem = Convert.ToString(model.ProductId);

               // var res = db1.Products.Where(x => x.ProductId == strItem).FirstOrDefault();

                    Product obj = new Product();
                    obj.ProductId = model.ProductId;
                    obj.ProductName = model.ProductName;
                    obj.CategoryId = model.CategoryId;

                    db1.Products.AddOrUpdate(obj);
                    //db1.Entry(obj).State = EntityState.Added;
                    db1.SaveChanges();

            }
            ModelState.Clear();

            return RedirectToAction("Productlist");
        }

        public ActionResult Productlist(int page=1)
        {

            var pageNumber = page;
            var pageSize = 5;
            var td = (from P in db1.Products
                      join C in db1.Categories
                            on P.CategoryId.ToString() equals C.CategoryId
                      select new
                            {
                          ProductId = P.ProductId,
                          ProductName = P.ProductName,
                          CategoryId = P.CategoryId,
                          CategoryName = C.CategoryName
                      }).OrderBy(x => x.ProductId).ToPagedList(pageNumber, pageSize)
        .Select(x => new Product()
        {
            ProductId = x.ProductId,
            ProductName = x.ProductName,
            CategoryId = x.CategoryId,
            CategoryName = x.CategoryName
        });

            List<Product> list_course = td.ToList<Product>();

            ViewBag.MyList = list_course;

            
            var products = db1.Products.OrderBy(x => x.ProductId).ToPagedList(pageNumber, pageSize);
            return View(products);
        }

        public ActionResult Delete(int id)
        {
            var strItem = Convert.ToString(id);
            var res = db1.Products.Where(x => x.ProductId == strItem).First();
            db1.Products.Remove(res);
            db1.SaveChanges();

            return RedirectToAction("Productlist");
        }


    }
}