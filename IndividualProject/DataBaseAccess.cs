using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class DataBaseAccess
    {
        public static SqlConnection AccessDB()
        {
            string connectionString = "";
            try
            {
                connectionString =
                @"Server = DESKTOP-U2PM7SO\SQLEXPRESS;Database = Individual;Trusted_Connection = True;";
            }
            catch (SqlException x)
            {
                Console.WriteLine(x);
            }
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            return sqlconnection;
        }

        public static string DateofSubmision()
        {
            var dateOfSub = DateTime.Now;
            return dateOfSub.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }



        public static void InsertMessage(SqlConnection conn)
        {
            using (conn)
            {

                try
                {
                    conn.Open();
                    Insert(conn);

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

        }

        public static void DeleteMessage(SqlConnection conn)
        {
            using (conn)
            {

                try
                {
                    conn.Open();
                    Delete(conn);

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

        }

        public static void UpadeMessage(SqlConnection conn)
        {
            using (conn)
            {

                try
                {
                    conn.Open();
                    Update(conn);

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
        }

        public static void ViewMessageAndUsers(SqlConnection conn)
        {
            using (conn)
            {

                try
                {
                    conn.Open();
                    ViewRole(conn);
                    ViewUserDetail(conn);
                    ViewMessageInfo(conn);

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
        }

        private static void ViewRole(SqlConnection conn)
        {

            SqlCommand insertcmd = new SqlCommand($"SELECT Id, Role FROM Privilege", conn);
            SqlDataReader readerUsers = insertcmd.ExecuteReader();
            Console.WriteLine("Roles: ");
            Console.WriteLine("ID\tRole\n");

            while (readerUsers.Read())
            {

                Console.WriteLine("{0}\t{1}\n",
                        readerUsers.GetInt32(0),
                        readerUsers.GetString(1));
                        
            }
            readerUsers.Close();
            int rowsInserted = insertcmd.ExecuteNonQuery();
            if (rowsInserted > 0)
            {
                Console.WriteLine("Insertion Successful");
                Console.WriteLine($"{rowsInserted} rows inserted Successfully");
            }
        }
        
        private static void ViewUserDetail(SqlConnection conn)
        {

            SqlCommand insertcmd = new SqlCommand($"SELECT Id, Name, Password, Role FROM UserDetail", conn);
            SqlDataReader readerUsers = insertcmd.ExecuteReader();
            Console.WriteLine("UserDetail: ");
            Console.WriteLine("ID\tName\t\tPassword\t\tRole\n");

            while (readerUsers.Read())
            {

                Console.WriteLine("{0}\t{1}\t\t{2}\t\t\t{3}\n",
                        readerUsers.GetInt32(0),
                        readerUsers.GetString(1),
                        readerUsers.GetString(2),
                        readerUsers.GetInt32(3));
            }
            readerUsers.Close();
            int rowsInserted = insertcmd.ExecuteNonQuery();
            if (rowsInserted > 0)
            {
                Console.WriteLine("Insertion Successful");
                Console.WriteLine($"{rowsInserted} rows inserted Successfully");
            }
        }
        //View Message
        private static void ViewMessageInfo(SqlConnection conn)
        {
            
            SqlCommand insertcmd = new SqlCommand($"SELECT ID, Message, DateOfSub, IdSender, IdReceiver FROM MessageInfo", conn);
            SqlDataReader readerMessages = insertcmd.ExecuteReader();
            Console.WriteLine("MessageInfo: ");
            Console.WriteLine("ID\tMessage\t\tDateOfSub\t\tIdSender\tIdReceiver\n");

            while (readerMessages.Read())
            {

                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t\t{4}",
                    readerMessages.GetInt32(0),
                    readerMessages.GetString(1),
                    readerMessages.GetDateTime(2),
                    readerMessages.GetInt32(3),
                    readerMessages.GetInt32(4));
                
                        
            }

            readerMessages.Close();
            int rowsInserted = insertcmd.ExecuteNonQuery();
            if (rowsInserted > 0)
            {
                Console.WriteLine("Insertion Successful");
                Console.WriteLine($"{rowsInserted} rows inserted Successfully");
            }
        }
        //Update Message
        private static void Update(SqlConnection conn)
        {
            User user = new User();
            Console.WriteLine("Insert ID and Text and UPDATE the Message");
            MessageInfo message = new MessageInfo();
            message.Id = Convert.ToInt32(Console.ReadLine());
            message.Text = Console.ReadLine();
            SqlCommand insertcmd = new SqlCommand($"UPDATE FROM MessageInfo SET Message = '{message.Text}' WHERE Id = '{message.Id}'", conn);
            int rowsInserted = insertcmd.ExecuteNonQuery();
            if (rowsInserted > 0)
            {
                Console.WriteLine("Insertion Successful");
                Console.WriteLine($"{rowsInserted} rows inserted Successfully");
            }
        }
        //Delete Message
        private static void Delete(SqlConnection conn)
        {
            User user = new User();
            Console.WriteLine("Insert ID Message and Delete Message");
            MessageInfo message = new MessageInfo();
            message.Id = Convert.ToInt32(Console.ReadLine());
            SqlCommand insertcmd = new SqlCommand($"Delete FROM MessageInfo Where Id = '{message.Id}'" , conn);
            int rowsInserted = insertcmd.ExecuteNonQuery();
            if (rowsInserted > 0)
            {
                Console.WriteLine("Insertion Successful");
                Console.WriteLine($"{rowsInserted} rows inserted Successfully");
            }
        }
        //Insert Message
        private static void Insert(SqlConnection conn)
        {
            User user = new User();
            Console.WriteLine("Enter The Receivers Name, the Message, your ID and the ID Of the Receiver to sent Message");
            user.Name = Console.ReadLine();
            MessageInfo message = new MessageInfo();
            message.Text = Console.ReadLine();
            var userSender = user.ID = Convert.ToInt32(Console.ReadLine());
            var userReceiver = user.ID = Convert.ToInt32(Console.ReadLine());
            var textCreation = FileAccess.CreateFile(message.Text, user.Name);
            SqlCommand insertcmd = new SqlCommand($"INSERT INTO MessageInfo (Message, DateOfSub, IdSender, IdReceiver) VALUES('{message.Text}', '{DateofSubmision()}', '{userSender}', '{userReceiver}')", conn);
            int rowsInserted = insertcmd.ExecuteNonQuery();
            if (rowsInserted > 0)
            {
                Console.WriteLine("Insertion Successful");
                Console.WriteLine($"{rowsInserted} rows inserted Successfully");
            }
            Console.WriteLine("Enter you message and Receiver to Append your message!");
            message.Text = Console.ReadLine();
            userReceiver = user.ID = Convert.ToInt32(Console.ReadLine());
            FileAccess.AppendMessage(message.Text, textCreation);
            SqlCommand cmdappend = new SqlCommand($"UPDATE MessageInfo SET Message = '{message.Text}' WHERE IdReceiver = '{userReceiver}'", conn);
            int newRowsUpdated = insertcmd.ExecuteNonQuery();
            if (newRowsUpdated > 0)
            {
                Console.WriteLine("Message Append Successfully!!");
                Console.WriteLine($"{newRowsUpdated} rows update succesfully");
            }
            
        }

        
    }
}


