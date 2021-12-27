using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Sales.Data.Sale
{
    public class SaleDAL
    {
        private readonly IConfiguration _configuration;
        string connectionString;
        public SaleDAL(IConfiguration configuration)
        {
            _configuration = configuration;

            connectionString = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

        }
        //public Entity.Sale.Sale GetSales()
        //{
        //    try
        //    {
        //        Entity.Sale.Sale sale = new Entity.Sale.Sale();
        //        List<Entity.Sale.SaleLine> saleLines = new List<Entity.Sale.SaleLine>();
        //        using (SqlConnection context = new SqlConnection(connectionString))
        //        {
        //            context.Open();

        //            using (SqlCommand command = context.CreateCommand())
        //            {
        //                command.CommandType = CommandType.StoredProcedure;
        //                command.CommandText = "[dbo].[stpGetSales]";

        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.HasRows)
        //                    {
        //                        while (reader.Read())
        //                        {
        //                            Entity.Sale.SaleLine salesLine = new Entity.Sale.SaleLine();

        //                            sale.Id = (Guid)reader["id_sale"];
        //                            salesLine.IdProduct = (Guid)reader["id_product"];
        //                            salesLine.IdCustomer = (Guid)reader["id_customer"];
        //                            salesLine.Quantity = reader["quantity"] as int? ?? default(int);
        //                            salesLine.UnitValue = reader["unit_value_product"] as decimal? ?? default(decimal);
        //                            salesLine.TotalValueForLine = reader["total_value_for_line"] as decimal? ?? default(decimal);
        //                            sale.TotalValue = reader["total_value"] as decimal? ?? default(decimal);

        //                            saleLines.Add(salesLine);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        sale.SaleLines = saleLines;
        //        return sale;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public Entity.Sale.Sale GetSaleByCustomerId(Guid prmId)
        {
            try
            {
                Entity.Sale.Sale sale = new Entity.Sale.Sale();
                List<Entity.Sale.SaleLine> saleLines = new List<Entity.Sale.SaleLine>();

                using (var context = new SqlConnection(connectionString))
                {
                    context.Open();
                    using (SqlCommand command = context.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[stpGetSalesByCustomerId]";
                        command.Parameters.Add("@prmIdCustomer", SqlDbType.UniqueIdentifier).Value = prmId;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Entity.Sale.SaleLine salesLine = new Entity.Sale.SaleLine();

                                    sale.Id = (Guid)reader["id_sale"];
                                    salesLine.IdProduct = (Guid)reader["id_product"];
                                    salesLine.IdCustomer = prmId;
                                    salesLine.Quantity = reader["quantity"] as int? ?? default(int);
                                    salesLine.UnitValue = reader["unit_value_product"] as decimal? ?? default(decimal);
                                    salesLine.TotalValueForLine = reader["total_value_for_line"] as decimal? ?? default(decimal);
                                    sale.TotalValue = reader["total_value"] as decimal? ?? default(decimal);

                                    saleLines.Add(salesLine);
                                }
                            }
                        }
                    }
                }
                sale.SaleLines = saleLines;
                return sale;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Inserta un producto en la BD
        /// </summary>
        /// <param name="prmProduct"></param>
        /// <returns></returns>
        public bool InsertSales(Guid saleId,DataTable salesDT, decimal saleTotalValue)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(connectionString))
                {
                    context.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[stpInsertSales]", context))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmSaleId", SqlDbType = SqlDbType.UniqueIdentifier, Value = saleId });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmSalesLines", SqlDbType = SqlDbType.Structured, Value = salesDT });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmTotalValue", SqlDbType = SqlDbType.Decimal, Value = saleTotalValue });

                        command.ExecuteScalar();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
