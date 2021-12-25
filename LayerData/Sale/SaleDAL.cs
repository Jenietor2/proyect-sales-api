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
        public List<Entity.Sale.Sale> GetSales()
        {
            try
            {
                List<Entity.Sale.Sale> salesList = new List<Entity.Sale.Sale>();

                using (SqlConnection context = new SqlConnection(connectionString))
                {
                    context.Open();

                    using (SqlCommand command = context.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[stpGetSales]";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Entity.Sale.Sale sale = new Entity.Sale.Sale();

                                    sale.Id = (Guid)reader["id_sale"];
                                    sale.IdProduct = (Guid)reader["id_product"];
                                    sale.IdCustomer = (Guid)reader["id_customer"];
                                    sale.Quantity = reader["quantity"] as int? ?? default(int);
                                    sale.UnitValue = reader["unit_value_product"] as decimal? ?? default(decimal);
                                    sale.TotalValue = reader["total_value"] as decimal? ?? default(decimal);

                                    salesList.Add(sale);
                                }
                            }
                        }
                    }
                }
                return salesList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Entity.Sale.Sale> GetSaleByCustomerId(Guid prmId)
        {
            try
            {
                List<Entity.Sale.Sale> saleList = new List<Entity.Sale.Sale>();

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
                                    Entity.Sale.Sale sale = new Entity.Sale.Sale();
                                    sale.Id = (Guid)reader["id_sale"];
                                    sale.IdProduct = (Guid)reader["id_product"];
                                    sale.IdCustomer = prmId;
                                    sale.Quantity = reader["quantity"] as int? ?? default(int);
                                    sale.UnitValue = reader["unit_value_product"] as decimal? ?? default(decimal);
                                    sale.TotalValue = reader["total_value"] as decimal? ?? default(decimal);

                                    saleList.Add(sale);
                                }
                            }
                        }
                    }
                }
                return saleList;
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
        public bool InsertSales(DataTable salesDT)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(connectionString))
                {
                    context.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[stpInsertSales]", context))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmSalesLines", SqlDbType = SqlDbType.Structured, Value = salesDT });

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
