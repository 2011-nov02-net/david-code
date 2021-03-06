﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloAspNetCore.Controllers
{
    public class ViewBasedController : Controller
    {
        public IActionResult HomePage()
        {
            // usually we return viewresults with the View helper method from the Controller base class
            return View("Home");
        }

        public IActionResult ViewWithLayout1()
        {
            // views can have a layout
            // a layout is a special kind of view that can't stand on its own,
            //  at some point is calls "@RenderBody()"
            // and that is where a "actual" view will go
            return View("ViewWithLayout1");
        }

        public IActionResult ViewWithLayout2()
        {
            return View(); // the zero-argument form of view method uses the current action name
        }
    }
}
