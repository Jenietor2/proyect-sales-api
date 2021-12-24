using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitValue { get; set; }
    }
}
