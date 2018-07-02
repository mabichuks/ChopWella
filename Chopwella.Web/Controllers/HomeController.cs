using Chopwella.Core;
using Chopwella.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServices<Staff> _context;
        public HomeController(IServices<Staff> context)
        {
            _context = context;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {

            return View();
        }
    }
}