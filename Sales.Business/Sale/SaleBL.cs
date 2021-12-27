using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sales.Business.Sale
{
    public class SaleBL
    {
        private readonly Data.Sale.SaleDAL saleDAL;
        private readonly IConfiguration _configuration;

        public SaleBL(IConfiguration configuration)
        {
            _configuration = configuration;
            saleDAL = new Data.Sale.SaleDAL(_configuration);
        }

        /*public List<Entity.Sale.Sale> GetAllSales()
        {
            return saleDAL.GetSales();
        }*/

        public Entity.Sale.Sale GetSalesByCustomerId(Guid id)
        {
            return saleDAL.GetSaleByCustomerId(id);
        }
        public bool CreateSale(Entity.Sale.Sale sale)
        {
            DataTable salesDT = new DataTable();
            salesDT = ListToDataTable(sale.SaleLines);
            return saleDAL.InsertSales(Guid.NewGuid(), salesDT, sale.TotalValue);
        }

        private DataTable ListToDataTable(List<Entity.Sale.SaleLine> salesList)
        {
            DataTable salesDT = new DataTable();
            salesDT.Clear();

            //salesDT.Columns.Add("id_sale", typeof(Guid));
            salesDT.Columns.Add("id_product", typeof(Guid));
            salesDT.Columns.Add("id_customer", typeof(Guid));
            salesDT.Columns.Add("quantity", typeof(int));
            salesDT.Columns.Add("unit_value_product", typeof(decimal));
            salesDT.Columns.Add("total_value_for_line", typeof(decimal));

           // Guid id = Guid.NewGuid();

            foreach (var sale in salesList)
            {
                DataRow row = salesDT.NewRow();

                //row["id_sale"] = id;
                row["id_product"] = sale.IdProduct;
                row["id_customer"] = sale.IdCustomer;
                row["quantity"] = sale.Quantity;
                row["unit_value_product"] = sale.UnitValue;
                row["total_value_for_line"] = sale.TotalValueForLine;

                salesDT.Rows.Add(row);
            }

            return salesDT;
        }

    }
}
