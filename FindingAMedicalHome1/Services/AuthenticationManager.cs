using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;

namespace FindingAMedicalHome1.Services
{
    public static class AuthenticationManager
    {
        public static async Task<bool> AuthenticateUser(string userName, string password)
        {
            var databasePassword = await GetUserPassword(userName);

            // if no password in the database, we probably can't find the user
            // authentication has failed
            if (databasePassword == null)
                return false;

            //compare the password provided from the client/browser to the password stored in the database.
            
            return password == databasePassword;
        }

        private static async Task<string> GetUserPassword(string userName)
        {
            

            using (var connection = new MySqlConnection("Server=clinicsystemdb.cfkpw0ap0abf.us-east-1.rds.amazonaws.com;user id=Lotusep5ep; Pwd=Pat123forsell; database=ClinicSysDB"))  // TODO: Get connection string 
            {
                using (var command = connection.CreateCommand())
                {
                    // build command
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "SELECT AdminPass FROM AdminUser WHERE AdminUserName = @userName"; //Look up credentials by username
                    command.Parameters.Add("@userName", MySqlDbType.VarChar).Value = userName;

                    // open connection
                    await connection.OpenAsync();

                    // execute query, returning value of the first column of the first row
                    var pwd = await command.ExecuteScalarAsync();

                    // C# null and Database NULL are two different things
                    // if Database null, return null
                    if (pwd == DBNull.Value)
                        return null;

                    // cast the password to a string
                    return (string)pwd;
                }
            }
        }
    }
}

