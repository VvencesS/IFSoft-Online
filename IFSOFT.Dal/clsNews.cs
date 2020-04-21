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
        public DataTable GetListByCateID(int cateID)
        {
            SqlCommand command = new SqlCommand("Select * from NewsCategories where CateID=@cateID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@cateID", cateID);

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
        public void Update(int CateID, string CategoryName, int Order, bool Active)
        {
            SqlCommand command = new SqlCommand("Update NewsCategories set vName=@CategoryName, [vOrder]=@Order, Active=@Active Where CateID=@CateID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@CategoryName", CategoryName);
            command.Parameters.AddWithValue("@Order", Order);
            command.Parameters.AddWithValue("@Active", Active);
            command.Parameters.AddWithValue("@CateID", CateID);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public void Delete(int CateID)
        {
            SqlCommand command = new SqlCommand("Delete From NewsCategories Where CateID=@CateID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@CateID", CateID);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
    }
}
