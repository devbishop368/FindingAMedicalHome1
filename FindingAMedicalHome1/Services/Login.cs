using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindingAMedicalHome1.Models;



namespace FindingAMedicalHome1.Services
{
    public class LoginViewModel
    {
        /*NEW CODE
        * 
        * Look up credentials by username
        * 
        * No match = invalid;
        * "Could not login"
        * else( (success)
        * Match for username -> check for password/compare passwords (compare Hashed values, actually)
        * if (match)
        * (success)
        * else
        * { No go son }
        * end         * 
        * 

            */
        /* NOTES FROM MEETING
         *
         *Databases{ Must be indexed! Must create new idAdminUser table to make Auto-Incrementing! }


        */
        
            /* Create a Credentials object to use userName to search - Karthik*/

        public void OperateOnDatabase(string userName, string password)
        {
            //Credentials User = new Credentials();
            //User.userName = UserName;

            using (var sqlConnection = new MySqlConnection(""))
            {
                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = "SELECT * FROM AdminUser WHERE AdminUserName = @userName"; //Look up credentials by username
                sqlCommand.Parameters.Add("@userName", MySqlDbType.VarChar).Value = userName;

                sqlConnection.Open();

                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if(@password == sqlReader.GetValue(2).ToString()/*Password*/) { /* LEFT OFF HERE */
                            /* Login Success!*/
                            //System.Windows.Forms.MessageBox.Show("Login Successful");

                            
                        }
                        else { /*Keep looking */ }
                    }
                }
            }
        }
        /* OR this way: */
        public void OperateOnDatabaseWithoutReader(string userName, string password)
        {
            using (var sqlConnection = new MySqlConnection(""))
            {
                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = "SELECT Password FROM AdminUser WHERE UserName = @userName"; //Look up credentials by username
                sqlCommand.Parameters.Add("@userName", MySqlDbType.VarChar).Value = userName;

                sqlConnection.Open();

                var pwd = sqlCommand.ExecuteScalar();
            }
        }
    /*
        public string CompareCredentials(string Username, string Pass)
        {
            List<Credentials> validCredentials = new List<Credentials>();
            MySqlConnection cnn;

            string indicator = "";
            string connString = @"Server=clinicsystemdb.cfkpw0ap0abf.us-east-1.rds.amazonaws.com;user id=Lotusep5ep; Pwd=Pat123forsell; database=ClinicSysDB"; //THis should NEVER 
            //be embedded in code like this! Move it to appsettings.json! Add "Using.Microsoft.COnfiguration)

            cnn = new MySqlConnection(connString);

            MySqlDataReader reader = null;

            cnn.Open();
            string sql = "Select * from AdminUsers where UserName = " + Username; //Changed "Select * from Users" to "Select * from AdminUsers"

            MySqlCommand command = new MySqlCommand(sql, cnn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                validCredentials.Add(new Credentials
                {
                    ID = reader.GetValue(0).ToString(),

                    UserName = reader.GetValue(1).ToString(),

                    Password = reader.GetValue(2).ToString(),

                    Cred = new List<Credentials>()

                });
            }

            foreach (Credentials CMD in validCredentials)
            {
                if (CMD.UserName != Username && CMD.Password != Pass)
                {
                    indicator = "Login failed"; // Login Failed
                }

                else if (CMD.UserName == Username && CMD.Password != Pass)
                {
                    indicator = "The password you entered is incorrect, please try again."; // Password is incorrect
                }
                else if (CMD.UserName != Username && CMD.Password == Pass)
                {
                    indicator = "Invalid username"; //Username is incorrect 
                }
                else
                {
                    indicator = "Login Successful"; // Login Successful 
                    return indicator;
                }
            }

            return indicator;

        }
        */
        /*test*/
}
}
