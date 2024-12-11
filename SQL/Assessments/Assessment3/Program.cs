using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=ICS-LT-D2YLV44\\SQLEXPRESS;database=SQLandADO;trusted_connection=true;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("InsertProduct", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductName", "Sample Product");
                command.Parameters.AddWithValue("@Price", 200.00);


                SqlParameter productIdParam = new SqlParameter("@GeneratedProductID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(productIdParam);

                SqlParameter discountedPriceParam = new SqlParameter("@DiscountedPrice", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(discountedPriceParam);


                command.ExecuteNonQuery();


                int generatedProductId = (int)productIdParam.Value;
                decimal discountedPrice = (decimal)discountedPriceParam.Value;


                Console.WriteLine($"Generated Product ID: {generatedProductId}");
                Console.WriteLine($"Discounted Price: {discountedPrice}");
            }
        }
    }
}
