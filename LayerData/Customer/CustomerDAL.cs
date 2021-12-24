using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sales.Data.Customer
{
    public class CustomerDAL
    {       
    
        private readonly IConfiguration _configuration;
        string connectionString;
        public CustomerDAL(IConfiguration configuration)
        {
            _configuration = configuration;

            connectionString = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

        }
        public Entity.Customer.Customer GetById(Guid prmId)
        {
            try
            {
                Entity.Customer.Customer customer = new Entity.Customer.Customer();

                using (var context = new SqlConnection(connectionString))
                {
                    context.Open();
                    using (SqlCommand command = context.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[stpGetCustomerById]";
                        command.Parameters.Add("@prmIdCustomer", SqlDbType.UniqueIdentifier).Value = prmId;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    customer.Id = prmId;
                                    customer.Cedula = reader["cedula"] as string;
                                    customer.Name = reader["name_customer"] as string;
                                    customer.LastName = reader["last_name_customer"] as string;
                                    customer.Phone = reader["phone_customer"] as string;
                                }
                            }
                        }
                    }
                }
                return customer;
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
        public List<Entity.Customer.Customer> GetAll()
        {
            try
            {
                List<Entity.Customer.Customer> CustomerList = new List<Entity.Customer.Customer>();

                using (SqlConnection cnnProduct = new SqlConnection(connectionString))
                {
                    cnnProduct.Open();

                    using (SqlCommand command = cnnProduct.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[stpGetCustomers]";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Entity.Customer.Customer customer = new Entity.Customer.Customer();

                                    customer.Id = (Guid)reader["id_customer"];
                                    customer.Cedula = reader["cedula"] as string;
                                    customer.Name = reader["name_customer"] as string;
                                    customer.LastName = reader["last_name_customer"] as string;
                                    customer.Phone = reader["phone_customer"] as string;

                                    CustomerList.Add(customer);
                                }
                            }
                        }
                    }
                }

                return CustomerList;
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
        public Guid Create(Entity.Customer.Customer customer)
        {
            try
            {
                using (SqlConnection cnnProduct = new SqlConnection(connectionString))
                {
                    cnnProduct.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[stpInsertCustomer]", cnnProduct))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmIdCustomer", SqlDbType = SqlDbType.UniqueIdentifier, Value = customer.Id });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmCedula", SqlDbType = SqlDbType.VarChar, Value = customer.Cedula });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmNameCustomer", SqlDbType = SqlDbType.VarChar, Value = customer.Name });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmLastNameCustomer", SqlDbType = SqlDbType.VarChar, Value = customer.LastName });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmPhone", SqlDbType = SqlDbType.VarChar, Value = customer.Phone });
                       
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
        public bool Update(Entity.Customer.Customer customer)
        {
            try
            {
                using (SqlConnection cnnProduct = new SqlConnection(connectionString))
                {
                    cnnProduct.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[stpUpdateCustomer]", cnnProduct))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmIdCustomer", SqlDbType = SqlDbType.UniqueIdentifier, Value = customer.Id });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmCedula", SqlDbType = SqlDbType.VarChar, Value = customer.Cedula });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmNameCustomer", SqlDbType = SqlDbType.VarChar, Value = customer.Name });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmLastNameCustomer", SqlDbType = SqlDbType.VarChar, Value = customer.LastName });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmPhone", SqlDbType = SqlDbType.VarChar, Value = customer.Phone });

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

        public bool Delete(Guid prmId)
        {
            try
            {
                using (SqlConnection cnnProdcut = new SqlConnection(connectionString))
                {
                    cnnProdcut.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[stpDeleteCustomerById]", cnnProdcut))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@prmIdCustomer", SqlDbType = SqlDbType.UniqueIdentifier, Value = prmId });

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
