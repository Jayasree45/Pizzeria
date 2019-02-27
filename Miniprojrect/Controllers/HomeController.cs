using Miniprojrect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Miniprojrect.Controllers
{
    public class HomeController : Controller
    {
        private Training_12DecMumbaiEntities3 db = new Training_12DecMumbaiEntities3();
      //  private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Offers()
        {
            ViewBag.Message = "Your offers page.";

            return View();
        }

      //  [Authorize(Roles ="Admin")]
        public ActionResult DemoView()
        {
            return View();
        }

        public ActionResult Customize()
        {

            var model = new List<ProjectPizza>();
            model = db.ProjectPizzas.ToList();
            return View(model);
        

           ////List<ProjectPizza> model = new List<ProjectPizza>();
           //// var query = (from cat in db.ProjectCategories join pro in db.ProjectPizzas on cat.PizzaID equals pro.PizzaID
           ////              where cat.CategoryID == 100
           ////             select new {
                          
           ////                 proID = pro.PizzaID,
           ////                 proPrice = pro.Price,
           ////                 proName = pro.PName,
           ////                 proImageURL = pro.ImageURL

           ////             }).ToList();

           //// foreach (var item in query) //retrieve each item and assign to model
           //// {
           ////     model.Add(new ProjectPizza()
           ////     {
                    
           ////         PizzaID = item.proID,
           ////         Price = item.proPrice,
           ////         PName = item.proName,
           ////         ImageURL = item.proImageURL
           ////     });
           //// }
                // query = db.ProjectPizzas.ToList();
                //return View(model);
        }

        [HttpPost]
        public ActionResult Customize(ProjectPizza model)
        {
            ProjectPizza pizz = new ProjectPizza();
            List<ProjectPizza> items;
            if (Session["items"] == null)
            {
                items = new List<ProjectPizza>();
                items.Add(model);
                Session.Add("items", items);
            }
            else
            {
                items = Session["items"] as List<ProjectPizza>;
                items.Add(model);
                Session["items"] = items;
            }
            return View();
        }




        public ActionResult NonVegCustomize()
        {

            var model = new List<ProjectPizza>();
            model = db.ProjectPizzas.ToList();
            return View(model);

            ////List<ProjectPizza> model = new List<ProjectPizza>();
            ////var query = (from cat in db.ProjectCategories
            ////             join pro in db.ProjectPizzas on cat.PizzaID equals pro.PizzaID
            ////             where cat.CategoryID == 101
            ////             select new
            ////             {

            ////                 proID = pro.PizzaID,
            ////                 proPrice = pro.Price,
            ////                 proName = pro.PName,
            ////                 proImageURL = pro.ImageURL

            ////             }).ToList();

            ////foreach (var item in query) //retrieve each item and assign to model
            ////{
            ////    model.Add(new ProjectPizza()
            ////    {

            ////        PizzaID = item.proID,
            ////        Price = item.proPrice,
            ////        PName = item.proName,
            ////        ImageURL = item.proImageURL
            ////    });
            ////}
            ////return View(model);

        }

        public ActionResult CustomizeNow()
        {
            ViewBag.Message = "Your Pizza Page.";

            return View();
        }

        [Authorize(Roles ="Admin,Employee,User")]
        public ActionResult ReviewOrder()
        {
            ViewBag.Message = "Your Pizza Page.";

            return View();
        }
    }
}