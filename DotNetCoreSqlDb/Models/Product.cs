using System;
using System.Collections.Generic;

namespace DotNetCoreSqlDb.Models;

public partial class Product
{
    public int ProductNum { get; set; }

    public string Department { get; set; }

    public string Commodity { get; set; }

    public string BrandTy { get; set; }

    public string NaturalOrganicFlag { get; set; }
}
