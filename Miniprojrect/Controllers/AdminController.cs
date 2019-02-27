using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Miniprojrect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Miniprojrect.Controllers
{
    [Authorize(Roles="Admin,Employee")]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string UserName = form["txtEmail"];
            string email = form["txtEmail"];
            string pwd = form["txtPassword"];

            //create default user 
            var user = new ApplicationUser();
            user.Email = email;
            user.UserName = UserName;
            string password = pwd;

            var newuser = UserManager.Create(user, pwd);
            UserManager.AddToRolesAsync("Employee");
         //   Session["Abc"] = newuser;
            return View();
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(FormCollection form)
        {
            string rolename = form["RoleName"];
            return View();
        }

        public ActionResult AssignRole()
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string username = form["txtUserName"];
            string rolename = form["RoleName"];
            ApplicationUser user = context.Users.Where(u => u.Email.Equals(username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(user.Id, rolename);

            return View("Index");
        }


    }
}