using Sales.Data.Product;
using System;
using System.Data.SqlClient;

namespace ConsolaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var context = new SqlConnection("Data Source=DESKTOP-5PLC5LP;Initial Catalog=Ventas;Integrated Security=True"))
                {
                    context.Open();
                    Console.WriteLine("Conectado");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ocurrio el siguiente error {ex.Message}");
            }
            
        }        
    }
}
