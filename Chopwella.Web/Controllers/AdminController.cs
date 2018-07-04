using Chopwella.Infrastructure;
using Chopwella.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserRepo _userRepo;

        public AdminController()
        {
            this._userRepo = new UserRepo();
        }
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateUsers()
        {
            var viewmodel = new UserViewModel
            {
                Roles = _userRepo.GetRoles
            };

            return View(viewmodel);
        }
    }
}