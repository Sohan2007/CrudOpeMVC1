using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class ProDetail1 : Controller
    {
        private readonly ApplicationDbContext _db;

        //[BindProperty]
        //public ProductDetail productDetail { get; set; }
        public ProDetail1(ApplicationDbContext db)
        {
            _db = db;
        }
        //get method to get all deatils    
        public IActionResult Index()
        {
            IQueryable<ProductDetail> proList =_db.ProductDetails;
            return View(proList);
        }

        
        public IActionResult CreateProduct()
        {
            ViewBag.ThisKey = "We are creating new product/ploicy";
            return View();                        
        }

        [HttpPost]
       // [ActionName("CreateProduct")]
        public IActionResult CreateProduct(ProductDetail product)
        {
            if (ModelState.IsValid)
            {
                _db.Add(product);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else 
            {
                ViewBag.ThisKey = "Please enter the value correctly";
                return View();
            }
            
        }

        public IActionResult EditPolicy(int? ID)
        {
            if (ID == null | ID == 0)
            {
                return NotFound();
            }
            else 
            {
                 var obj=_db.ProductDetails.Find(ID);
                if (obj == null)
                {
                    return NotFound();
                }

                TempData["key"] = "Edit";
                
                return View("CreateProduct",obj);
            }

            
        }
        [HttpPost]
        public IActionResult EditPolicy(ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                _db.ProductDetails.Update(productDetail);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["key1"] = "Do proper Editing";
                return View(); 
            }
           
        }

        public IActionResult DeletePloicy(int? ID)
        {
            var obj = _db.ProductDetails.Find(ID);
            if (obj == null )
            {
                return NotFound();
            }
            else
            {                
                return View(obj);
            }
            
        
        }

        [HttpPost]
        public IActionResult DeletePloicy(ProductDetail obj)
        {
            _db.ProductDetails.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }





    }
}
