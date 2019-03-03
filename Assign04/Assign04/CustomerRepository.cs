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


        public static List<string> GetDistinctProvinces()
        {

            List<string> provinces;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT DISTINCT Province
                                FROM Customer";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    provinces = new List<string>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string province = null;
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
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

        public static List<Customer> GetCustomersByProvince(string provinceName)
        {
            List<Customer> customers;

            using(SqlConnection conn = new SqlConnection(connString))
            {
                string query;
                if(provinceName == "ALL")
                {
                    query = @"SELECT CompanyName, City, Province,
                                PostalCode, CreditHold From Customer";
                }
                else
                {
                    query = @"SELECT CompanyName, City, Province,
                            PostalCode, CreditHold From Customer
                            WHERE Province = @province ";
                }

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@province", provinceName);

                    conn.Open();

                    customers = new List<Customer>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string companyName;
                        string city = null;
                        string province = null;
                        string postalCode = null;
                        bool creditHold = false;

                        while(reader.Read())
                        {
                            companyName = reader["CompanyName"] as string;

                            if(!reader.IsDBNull(1))
                            {
                                city = reader["City"] as string;
                            }

                            if (!reader.IsDBNull(2))
                            {
                                province = reader["Province"] as string;
                            }

                            if (!reader.IsDBNull(3))
                            {
                                postalCode = reader["PostalCode"] as string;
                            }

                            if (!reader.IsDBNull(4))
                            {
                                creditHold = (bool)reader["CreditHold"];
                            }

                            customers.Add(new Customer(companyName, city, province, postalCode, creditHold));

                            city = null;
                            province = null;
                            postalCode = null;
                            creditHold = false;
                        }
                    }
                    return customers;
                }
            }
        }
    }
}
