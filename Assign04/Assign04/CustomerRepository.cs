using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign04
{
    class CustomerRepository
    {
        private static string connString = @"Server=tcp:skeena.database.windows.net,1433;
                                            Initial Catalog=comp2614;
                                            User ID=student;
                                            Password=93nu5_zZ5b;
                                            Encrypt=True;
                                            TrustServerCertificate=False;
                                            Connection Timeout=30;";


        public static List<string> getDistinctProvinces()
        {
            List<string> provinces;

            using(SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT DISTINCT Province
                                FROM Customer";
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    provinces = new List<string>();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string province = null;
                        while(!reader.Read())
                        {
                            if(!reader.IsDBNull(0))
                            {
                                province = reader["Province"] as string;
                            }

                            provinces.Add(province);

                            province = null;
                        }
                    }
                    provinces.Add("ALL");
                    return provinces;
                }
            }
        }
    }
}
