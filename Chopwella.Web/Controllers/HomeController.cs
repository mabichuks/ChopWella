using Chopwella.Core;
using Chopwella.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChopWellaService<CheckIn> _chopWellaService;
        public HomeController(ChopWellaService<CheckIn> chopWellaService)
        {
            _chopWellaService = chopWellaService;
        }
        // GET: Home
        public ActionResult Index()
        {
            List<CheckIn> all = _chopWellaService.GetAll().ToList();
            return View(all);
        }
    }
}