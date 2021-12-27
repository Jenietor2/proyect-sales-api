using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Entity.Sale
{
    public class Sale : EntityBase.EntityBase
    {
        public List<SaleLine> SaleLines { get; set; }
        public decimal TotalValue { get; set; }
    }
}
