using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class LoginScreen
    {
        public static User Login(SqlConnection conn, User user)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    //Check the userName from the dataBase and show to him
                    LoginAccessToDataBase(conn, user);
                }
                catch (SqlException x)
                {
                    Console.WriteLine(x.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return user;

        }
        //User Login
        private static User LoginAccessToDataBase(SqlConnection conn, User user)
        {
            Console.WriteLine("Enter your Name and Password and Role to Login");
            user.Name = Console.ReadLine();
            user.Password = Console.ReadLine();
            var role = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmdLogin = new SqlCommand($" SELECT ID, Name, Password, Role FROM UserDetail WHERE Name = '{user.Name}' AND Password = '{user.Password}' AND Role = '{role}'", conn);
            SqlDataReader reader = cmdLogin.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("User Logged In Succesfully");
                Console.WriteLine("ID\tName\tPassword\tRole");
                Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}\t {reader.GetString(2)}\t\t{reader.GetInt32(3)}");
            }
            reader.Close();

            SqlCommand cmdSelect = new SqlCommand($"SELECT COUNT (*) FROM UserDetail  WHERE Name = '{user.Name}' AND Password = '{user.Password}'", conn);
            int result = (int)cmdSelect.ExecuteScalar();//ExecuteScalar first row of the first column fernei kai epistrefei object to opoio to kanoume int se mia mtavliti result
            if (result > 0)
            {
                Console.WriteLine($"Found User '{user.Name}'");
            }
            else
            {
                Console.WriteLine($"" +
                    $"Not Found");
            }
            return user;
        }
    }
}
