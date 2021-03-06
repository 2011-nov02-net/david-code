﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloAspNetCore.Controllers
{
    public class HelloController
    {

        // action methods' job is to fulfill the user's requests and return some IActionResult
        public IActionResult Action1()
        {
            Console.WriteLine("action method?");

            // ContentResult is the most flexible, low-level IActionResult
            return new ContentResult
            {
                Content = "<html><head></head><body>Hello from action (contentresult)</body></html>",
                ContentType = "text/html",
                StatusCode = 200
            };

            // instead we'll use ViewResult
            // This will handle our Razor Views. Views are a powerful HTML templating thing
        }

        // sources for action method parameters... (automatic deserization)
        //      route parameters in the URL (configured with {} in the route patterns in the Startup file)
        //      query string parameters in the URL (automatic, no config needed, if the param name matches)
        //      request body (e.g. from form data)
        //      some others... http headers, if you configure things right

        // the process of filling in action method parameters is called model binding
        //  typically problems in model binding do not throw exceptions, they just leave the .NET values at their defaults
        public IActionResult ParameterizedAction(string param1, int param2)
        {
            Console.WriteLine("action method?");

            // ContentResult is the most flexible, low-level IActionResult
            return new ContentResult
            {
                Content = $"<html><head></head><body>Hello {param1}, {param2} from action (contentresult)</body></html>",
                ContentType = "text/html",
                StatusCode = 200
            };
        }

        public IActionResult Redirect1()
        {
            return new RedirectToRouteResult("hello-controller-generic", new { controller = "Hello", action = "Redirect2" });
            //return new RedirectToActionResult(actionName: "Redirect2", controllerName: "Hello", routeValues: null);
        }

        public IActionResult Redirect2()
        {
            return new RedirectToActionResult(actionName: "Redirect1", controllerName: "Hello", routeValues: null);
        }
    }
}
