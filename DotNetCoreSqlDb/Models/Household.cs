using System;
using System.Collections.Generic;

namespace DotNetCoreSqlDb.Models;

public partial class Household
{
    public short HshdNum { get; set; }

    public string L { get; set; }

    public string AgeRange { get; set; }

    public string Marital { get; set; }

    public string IncomeRange { get; set; }

    public string Homeowner { get; set; }

    public string HshdComposition { get; set; }

    public string HhSize { get; set; }

    public string Children { get; set; }
}
