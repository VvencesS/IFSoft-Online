using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IFSOFT.Dal
{
    public class clsAdminUser
    {
        public void Insert(string userName, string password, string fullName, string address, byte role ,bool active)
        {
            SqlCommand command = new SqlCommand("Insert into AdminUsers values(@userName, @password, @fullName, @address, @role, @active)");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@userName", userName);
            command.Parameters.AddWithValue("@password", BuildPassword(password));
            command.Parameters.AddWithValue("@fullName", fullName);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@role", role);
            command.Parameters.AddWithValue("@active", active);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public DataTable Login(string userName, string password)
        {
            SqlCommand command = new SqlCommand("Select * from AdminUsers where UserName=@userName and Password=@password");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@userName", userName);
            command.Parameters.AddWithValue("@password", BuildPassword(password));

            return SQLDB.SQLDB.GetData(command);
        }
        protected string BuildPassword(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for(int i =0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
