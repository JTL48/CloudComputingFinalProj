using System.Collections.Generic;
using System;
using System.Linq;
using DotNetCoreSqlDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreSqlDb.Models.View
{
    public class HouseholdOverviewView
    {
        public int BasketNum { get; set; }
        public short HshdNum { get; set; }
        public string L { get; set; }
        public string AgeRange { get; set; }
        public string Marital { get; set; }
        public string IncomeRange { get; set; }
        public string Homeowner { get; set; }
        public string HshdComposition { get; set; }
        public string HhSize { get; set; }
        public string Children { get; set; }
        public int ProductNum { get; set; }
        public string Department { get; set; }
        public string Commodity { get; set; }
        public string BrandTy { get; set; }
        public string NaturalOrganicFlag { get; set; }
        public DateTime Purchase { get; set; }
        public double Spend { get; set; }
        public float Units { get; set; }
        public string StoreR { get; set; }
        public byte WeekNum { get; set; }
        public short Year { get; set; }

        public static IEnumerable<HouseholdOverviewView> GetHouseholdOverview(MyDatabaseContext _context)
        {
            var context = new cloudcomputingfinalprojdatasciencedatabaseContext();
            var result = from t in context.Transactions
                         join h in context.Households on t.HshdNum equals h.HshdNum
                         join p in context.Products on t.ProductNum equals p.ProductNum
                         select new HouseholdOverviewView
                         {
                             BasketNum = t.BasketNum,
                             HshdNum = h.HshdNum,
                             L = h.L,
                             AgeRange = h.AgeRange,
                             Marital = h.Marital,
                             IncomeRange = h.IncomeRange,
                             Homeowner = h.Homeowner,
                             HshdComposition = h.HshdComposition,
                             HhSize = h.HhSize,
                             Children = h.Children,
                             ProductNum = p.ProductNum,
                             Department = p.Department,
                             Commodity = p.Commodity,
                             BrandTy = p.BrandTy,
                             NaturalOrganicFlag = p.NaturalOrganicFlag,
                             Purchase = t.Purchase,
                             Spend = t.Spend,
                             Units = t.Units,
                             StoreR = t.StoreR,
                             WeekNum = t.WeekNum,
                             Year = t.Year
                         };
            return result.ToList();
        }
    }
}
