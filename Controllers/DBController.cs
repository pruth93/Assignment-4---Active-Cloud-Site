using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smithsonian.DataAccess;
using Smithsonian.Models;

namespace Smithsonian.Controllers
{
    public class DBController : Controller
    {
        public ApplicationDbContext dbContext;

        public DBController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}


