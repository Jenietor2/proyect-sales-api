using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Entity.Sale
{
    public class Sale : EntityBase.EntityBase
    {
        public Guid IdProduct { get; set; }
        public Guid IdCustomer { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TotalValue { get; set; }
    }
}
