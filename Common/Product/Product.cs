using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Entity
{
    public class Product : EntityBase.EntityBase
    {
        public string Name { get; set; }
        public decimal UnitValue { get; set; }
    }
}
