using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Controllers;

namespace TheWorldTree.Areas.FrontHome
{
    [Area("FrontHome")]
    public class FrontHomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
