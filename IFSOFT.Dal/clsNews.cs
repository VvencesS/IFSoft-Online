using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace IFSOFT.Dal
{
    public class clsNews
    {
        public DataTable GetList()
        {
            SqlCommand command = new SqlCommand("Select * from NewsCategories");
            command.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(command);
        }
        public void Insert(string CategoryName, int Order, bool Active)
        {
            SqlCommand command = new SqlCommand("Insert into NewsCategories values (@CategoryName, @Order, @Active)");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@CategoryName", CategoryName);
            command.Parameters.AddWithValue("@Order", Order);
            command.Parameters.AddWithValue("@Active", Active);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
    }
}
