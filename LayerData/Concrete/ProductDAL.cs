using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Common;
using Microsoft.Extensions.Options;
using Sales.Data.Product.Abstract;
using Sales.Entity;

namespace Sales.Data.Product
{
    public class ProductDAL : AbstractCommonDAL
    {
        //private readonly IOptions<ConfigurationManager> _configurationService;
        //string defaultConnection;
        //public ProductDAL(IOptions<ConfigurationManager> configurationservice)
        //{
        //    _configurationService = configurationservice;
        //    defaultConnection = _configurationService.Value.DefaultConnection;
        //}

        //public string GetConection()
        //{
        //    return defaultConnection;
        //}
        /// <summary>
        /// Obtiene un producto dado su Id
        /// </summary>
        /// <param name="prmId"></param>
        /// <returns>Entity.Product</returns>
        public Entity.Product GetProductById(Guid prmId)
        {
            try
            {
                Entity.Product product = new Entity.Product();

                using (var context = new SqlConnection(defaultConnectionString))
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
                                    product.Name = reader["nombre_producto"] as string;
                                    product.UnitValue = reader["valor_unitario_producto"] as decimal? ?? default(decimal);
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

                using (SqlConnection cnnProduct = new SqlConnection(defaultConnectionString))
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

                                    product.Id = (Guid)reader["id_producto"];
                                    product.Name = reader["nombre_producto"] as string;
                                    product.UnitValue = reader["valor_unitario_producto"] as decimal? ?? default(decimal);

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
                using (SqlConnection cnnProduct = new SqlConnection(defaultConnectionString))
                {
                    cnnProduct.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[stpInsertProductd]", cnnProduct))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmIdProduct", SqlDbType = SqlDbType.VarChar, Value = prmProduct.Id });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmNameProduct", SqlDbType = SqlDbType.VarChar, Value = prmProduct.Name });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmValueUnitProduct", SqlDbType = SqlDbType.Decimal, Value = prmProduct.UnitValue });
                       
                        return (Guid)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception)
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
                using (SqlConnection cnnProduct = new SqlConnection(defaultConnectionString))
                {
                    cnnProduct.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[stpUpdateProductd]", cnnProduct))
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
                using (SqlConnection cnnProdcut = new SqlConnection(defaultConnectionString))
                {
                    cnnProdcut.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[stpDeleteProductdById]", cnnProdcut))
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
