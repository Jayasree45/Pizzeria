using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Miniprojrect.Models;

namespace Miniprojrect.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProjectIngredientsController : Controller
    {
        private Training_12DecMumbaiEntities3 db = new Training_12DecMumbaiEntities3();

        // GET: ProjectIngredients
        public ActionResult Index()
        {
            //var projectIngredients = db.ProjectIngredients.Include(p => p.ProjectCategory);
            //return View(projectIngredients.ToList());
            return View();
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Image/" + ImageName);
                    
                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
                ProjectIngredient newRecord = new ProjectIngredient();

                newRecord.IngredientID = Convert.ToInt32(Request.Form["PizzaID"]);
                newRecord.IngredientName = Request.Form["PName"];
                newRecord.ImageURL = ImageName;
                //newRecord.Category = Request.Form["Category"];
                newRecord.Price = Convert.ToInt32(Request.Form["Price"]);
                db.ProjectIngredients.Add(newRecord);
                db.SaveChanges();

            }
            //Display records
            return RedirectToAction("../ProjectIngredients/Display1");
        }

        public ActionResult Display1()
        {
            return View();
        }

       

        //// GET: ProjectIngredients/Delete/5
        //public ActionResult Delete()
        //{
           
        //    return View();
        //}

        //// POST: ProjectIngredients/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed()
        //{
        //    ProjectIngredient newRecord = new ProjectIngredient();

        //    newRecord.IngredientID = Convert.ToInt32(Request.Form["IID"]);
        //    newRecord.IngredientName = Request.Form["IName"];
        //    newRecord.ImageURL = Request.Form["iImage"]; 
        //    //newRecord.Category = Request.Form["Category"];
        //    newRecord.Price = Convert.ToInt32(Request.Form["Price"]);
        //    db.ProjectIngredients.Remove(newRecord);
        //    db.SaveChanges();

            
        //    return RedirectToAction("Index");
        //}

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
