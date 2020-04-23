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
        //NewsCategories
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

        //NewsDetail
        public void InsertDetail(int cateID, string title, string desc, string content, string image, DateTime createDate, string author, bool active)
        {
            SqlCommand command = new SqlCommand("Insert into NewsDetail values(@cateID, @title, @desc, @content, @image, @createDate, @author, @active)");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@cateID", cateID);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@desc", desc);
            command.Parameters.AddWithValue("@content", content);
            command.Parameters.AddWithValue("@image", image);
            command.Parameters.AddWithValue("@createDate", createDate);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@active", active);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public DataTable GetListNewsDetailAll()
        {
            SqlCommand command = new SqlCommand("Select * from NewsDetail");
            command.CommandType = CommandType.Text;

            return SQLDB.SQLDB.GetData(command);
        }
        public DataTable GetListNewsDetail(int cateID)
        {
            SqlCommand command = new SqlCommand("Select * from NewsDetail Where CateID=@cateID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@cateID", cateID);

            return SQLDB.SQLDB.GetData(command);
        }
        public DataTable GetListByDelID(int delID)
        {
            SqlCommand command = new SqlCommand("Select * from NewsDetail where DelID=@delID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@delID", delID);

            return SQLDB.SQLDB.GetData(command);
        }
        public void UpdateDetail(int delID, int cateID, string title, string desc, string content, string image, string author, bool active)
        {
            SqlCommand command = new SqlCommand("Update NewsDetail set CateID=@cateID, vTitle=@title, vDesc=@desc, vContent=@content, vImage=@image, vAuthor=@author, Active=@active Where DelID=@delID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@cateID", cateID);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@desc", desc);
            command.Parameters.AddWithValue("@content", content);
            command.Parameters.AddWithValue("@image", image);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@active", active);
            command.Parameters.AddWithValue("@delID", delID);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public void DeleteDetail(int delID)
        {
            SqlCommand command = new SqlCommand("Delete from NewsDetail Where DelID=@delID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@delID", delID);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
    }
}
