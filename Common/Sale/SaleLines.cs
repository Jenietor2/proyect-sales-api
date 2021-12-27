using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Entity.Sale
{
    public class SaleLine 
    {
        public Guid IdProduct { get; set; }
        public Guid IdCustomer { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TotalValueForLine { get; set; }
    }
}
