using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Models;
using DotNetCoreSqlDb.Models.View;

namespace DotNetCoreSqlDb.Controllers
{
    public class HouseholdOverviewController : Controller
    {

        private readonly MyDatabaseContext _context;



        public HouseholdOverviewController(MyDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var context = new cloudcomputingfinalprojdatasciencedatabaseContext();
            var model = HouseholdOverviewView.GetHouseholdOverview(_context);
            //var context = new cloudcomputingfinalprojdatasciencedatabaseContext();
            //var householdOverview = GetHouseholdOverview(context)
            //var slabs = context.Set<HouseholdOverviewView>()
            //.OrderBy(s => s.HshdNum)
            //.OrderBy(s => s.BasketNum)
            //.OrderBy(s => s.Year)
            //.OrderBy(s => s.ProductNum)
            //.OrderBy(s => s.Department)
            //.OrderBy(s => s.Commodity);
            return View(model);
        }
    }
}