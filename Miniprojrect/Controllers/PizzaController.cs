using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Miniprojrect.Models;

namespace Miniprojrect.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PizzaController : Controller
    {
        private Training_12DecMumbaiEntities3 db = new Training_12DecMumbaiEntities3();
        // GET: Pizza
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddPizza()
        {
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
                ProjectPizza newRecord = new ProjectPizza();

                newRecord.PizzaID = Convert.ToInt32(Request.Form["PizzaID"]);
                newRecord.PName = Request.Form["PName"];
                newRecord.Category = Request.Form["Category"];
                newRecord.ImageURL = ImageName;         
                newRecord.Price = Convert.ToInt32(Request.Form["Price"]);
                db.ProjectPizzas.Add(newRecord);
                db.SaveChanges();

            }
            //Display records
            return RedirectToAction("../Pizza/Display");
        }
        public ActionResult Display()
        {
            return View();
        }
    }
}