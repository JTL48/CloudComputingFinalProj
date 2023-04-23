using System.Collections.Generic;
using System;

namespace DotNetCoreSqlDb.Models.View
{
    public class HouseholdOverviewView
    {
        public IEnumerable<Household> Households { get; set; }
        public IEnumerable<Product> Products{ get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
