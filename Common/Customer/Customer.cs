using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Entity.Customer
{
    public class Customer : EntityBase.EntityBase
    {
        public string Cedula { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
