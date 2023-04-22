using System;
using System.Collections.Generic;

namespace DotNetCoreSqlDb.Models;

public partial class Transaction
{
    public int BasketNum { get; set; }

    public short HshdNum { get; set; }

    public DateTime Purchase { get; set; }

    public int ProductNum { get; set; }

    public double Spend { get; set; }

    public float Units { get; set; }

    public string StoreR { get; set; }

    public byte WeekNum { get; set; }

    public short Year { get; set; }
}
