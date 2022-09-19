using System;
using System.Data.SqlClient;

namespace Pertemuan_6
{
    class Program
    {
        SqlConnection sqlConnection;


        string connectionString = "Data Source=DESKTOP-6TUDK2G;Initial Catalog=SIBKMNET;User ID=sibkmnet;Password=1234567890;Connect Timeout=30;";


        static void Main(string[] args)
        {
            Program program = new Program();
            //program.GetAll();
            //program.GetById(1);

            //Kota kota = new Kota()
            //{
            //    Name = "Korea"
            //};
            //program.Insert(kota);

            //Kota kota = new Kota()
            //{
            //    Update = "Jepang",
            //    Id = 5
            //};

            //program.GetAll();

            //program.Delete(4);
            program.GetAll();
        }

        //Select

        void GetAll()
        {
            string query = "SELECT * FROM Kota";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - " + sqlDataReader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void GetById(int id)
        {
            string query = "SELECT * FROM Kota WHERE Id = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id; 


            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - " + sqlDataReader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        //Insert

        void Insert( Kota kota)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@name";
                sqlParameter.Value = kota.Name;

                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Kota " +
                        "(Name) VALUES (@name)";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        //Update
        void Update(Kota kota)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                SqlParameter sqlParameter1 = new SqlParameter();

                sqlParameter.ParameterName = "@update";
                sqlParameter.Value = kota.Update;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter1.ParameterName = "@id";
                sqlParameter1.Value = kota.Id;

                sqlCommand.Parameters.Add(sqlParameter1);

                try
                {
                    sqlCommand.CommandText = "UPDATE Kota SET Name = (@update)" + "WHERE Id = (@id)";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
                //sqlConnection.Open();
                //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //sqlCommand.Transaction = sqlTransaction;

                //SqlParameter sqlParameter = new SqlParameter();
                //sqlParameter.ParameterName = "@name";
                //sqlParameter.Value = kota.Name;

                //sqlCommand.Parameters.Add(sqlParameter);

                //try
                //{
                //    sqlCommand.CommandText = "UPDATE Kota SET " +
                //        "(Name) VALUES (@name)" + "WHERE @id";
                //    sqlCommand.ExecuteNonQuery();
                //    sqlTransaction.Commit();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.InnerException);
                //}
            }
        }

        //Delete
        void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = id;

                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.CommandText = "DELETE FROM Kota WHERE Id = @id";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

    }
}
