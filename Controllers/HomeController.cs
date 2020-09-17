using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smithsonian.APIHandlerManager;
using Smithsonian.Models;
using Smithsonian.DataAccess;

namespace Smithsonian.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        } 
        
        public IActionResult DataModel()
        {
            return View();
        }

        public IActionResult Art()
        {
            APIHandler webHandler = new APIHandler();
            Rootobject artcol = webHandler.GetData();

            return View(artcol);
        }

        public IActionResult Chart()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("title,pages,author,publisher,year_published")] Attributes book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        //public IActionResult Chart()
        //{
        //            APIHandler webHandler = new APIHandler();
        //           Rootobject artcol = webHandler.GetData();
        //           Chart c = new Chart();
        //  new Chart 
        //  return View(artcol);
        //}
        /*
                public IActionResult MyChart()
                {
                    Chart x = new Chart(width: 800, height: 200).AddSeries(
                        chartType: "column",
                        xValue: new[] { "1", "2", "3", "4", "5" },
                        yValues: new[] { 1, 2, 3, 4, 5 })
                        .Write("png");

                    return null;
                }*/
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
