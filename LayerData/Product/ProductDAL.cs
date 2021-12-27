using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sales.Data.Product.Abstract;
using Sales.Entity;

namespace Sales.Data.Product
{
    public class ProductDAL : AbstractCommonDAL
    {
        private readonly IConfiguration _configuration;
        string connectionString;
        public ProductDAL(IConfiguration configuration)
        {
            _configuration = configuration;

            connectionString = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

        }
        public Entity.Product GetProductById(Guid prmId)
        {
            try
            {
                Entity.Product product = new Entity.Product();

                using (var context = new SqlConnection(connectionString))
                {
                    context.Open();
                    using (SqlCommand command = context.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[stpGetProductById]";
                        command.Parameters.Add("@prmIdProduct", SqlDbType.UniqueIdentifier).Value = prmId;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    product.Id = prmId;
                                    product.Name = reader["name_product"] as string;
                                    product.UnitValue = reader["unit_value_product"] as decimal? ?? default(decimal);
                                }
                            }
                        }
                    }
                }
                return product;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtiene los productos desde BD
        /// </summary>
        /// <returns></returns>
        public List<Entity.Product> GetProducts()
        {
            try
            {
                List<Entity.Product> productsList = new List<Entity.Product>();

                using (SqlConnection cnnProduct = new SqlConnection(connectionString))
                {
                    cnnProduct.Open();

                    using (SqlCommand command = cnnProduct.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[stpGetProducts]";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Entity.Product product = new Entity.Product();

                                    product.Id = (Guid)reader["id_product"];
                                    product.Name = reader["name_product"] as string;
                                    product.UnitValue = reader["unit_value_product"] as decimal? ?? default(decimal);

                                    productsList.Add(product);
                                }
                            }
                        }
                    }
                }

                return productsList;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Inserta un producto en la BD
        /// </summary>
        /// <param name="prmProduct"></param>
        /// <returns></returns>
        public Guid InsertProduct(Entity.Product prmProduct)
        {
            try
            {
                using (SqlConnection cnnProduct = new SqlConnection(connectionString))
                {
                    cnnProduct.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[stpInsertProduct]", cnnProduct))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmIdProduct", SqlDbType = SqlDbType.UniqueIdentifier, Value = prmProduct.Id });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmNameProduct", SqlDbType = SqlDbType.VarChar, Value = prmProduct.Name });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmValueUnitProduct", SqlDbType = SqlDbType.Decimal, Value = prmProduct.UnitValue });
                       
                        return (Guid)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Actualiza un producto segun su Id
        /// </summary>
        /// <param name="prmProduct"></param>
        /// <returns></returns>
        public bool UpdateProduct(Entity.Product prmProduct)
        {
            try
            {
                using (SqlConnection cnnProduct = new SqlConnection(connectionString))
                {
                    cnnProduct.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[stpUpdateProduct]", cnnProduct))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmIdProduct", SqlDbType = SqlDbType.UniqueIdentifier, Value = prmProduct.Id });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmNameProduct", SqlDbType = SqlDbType.VarChar, Value = prmProduct.Name });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmValueUnitProduct", SqlDbType = SqlDbType.Decimal, Value = prmProduct.UnitValue });

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteProductById(Guid prmId)
        {
            try
            {
                using (SqlConnection cnnProdcut = new SqlConnection(connectionString))
                {
                    cnnProdcut.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[stpDeleteProductById]", cnnProdcut))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmIdProduct", SqlDbType = SqlDbType.UniqueIdentifier, Value = prmId });

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
