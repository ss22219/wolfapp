using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Wolf.Core.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return Content(this.GetHashCode().ToString());
        }
    }
}
