using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IFSOFT.Dal
{
    public class clsProduct
    {
        public DataTable GetList()
        {
            SqlCommand command = new SqlCommand("Select * from ProductCategories");
            command.CommandType = CommandType.Text;

            return SQLDB.SQLDB.GetData(command);
        }
        public DataTable GetListByCategoryID(int proID)
        {
            SqlCommand command = new SqlCommand("Select * from ProductCategories where ProID=@proID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@proID", proID);

            return SQLDB.SQLDB.GetData(command);
        }
        public void Insert(string vName, int vOrder, bool active)
        {
            SqlCommand command = new SqlCommand("Insert into ProductCategories values(@vName,@vOrder,@active)");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@vName", vName);
            command.Parameters.AddWithValue("@vOrder", vOrder);
            command.Parameters.AddWithValue("@active", active);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public void Update(int proID, string vName, int vOrder, bool active)
        {
            SqlCommand command = new SqlCommand("Update ProductCategories set vName=@vName, vOrder=@vOrder, Active=@active where ProID=@proID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@vName", vName);
            command.Parameters.AddWithValue("@vOrder", vOrder);
            command.Parameters.AddWithValue("@active", active);
            command.Parameters.AddWithValue("@proID", proID);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public void Delete(int proID)
        {
            SqlCommand command = new SqlCommand("Delete from ProductCategories where ProID=@proID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@proID", proID);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public void InsertProductDetail(int proID, int vCode, string vName, string vDesc, string vContent, string vImage, 
            int iQuantity, float vPrice, DateTime createDate, string iView, bool active)
        {
            SqlCommand command = new SqlCommand("Insert into ProductDetail values(@proID,@vCode,@vName,@vDesc,@vContent,@vImage,@iQuantity,@vPrice,@createDate,@iView,@active)");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@proID", proID);
            command.Parameters.AddWithValue("@vCode", vCode);
            command.Parameters.AddWithValue("@vName", vName);
            command.Parameters.AddWithValue("@vDesc", vDesc);
            command.Parameters.AddWithValue("@vContent", vContent);
            command.Parameters.AddWithValue("@vImage", vImage);
            command.Parameters.AddWithValue("@iQuantity", iQuantity);
            command.Parameters.AddWithValue("@vPrice", vPrice);
            command.Parameters.AddWithValue("@createDate", createDate);
            command.Parameters.AddWithValue("@iView", iView);
            command.Parameters.AddWithValue("@active", active);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public DataTable GetListProductDetailAll()
        {
            SqlCommand command = new SqlCommand("Select * from ProductDetail");
            command.CommandType = CommandType.Text;

            return SQLDB.SQLDB.GetData(command);
        }
        public DataTable GetListProductDetail(int proID)
        {
            SqlCommand command = new SqlCommand("Select * from ProductDetail where ProID=@proID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@proID", proID);

            return SQLDB.SQLDB.GetData(command);
        }
        public DataTable GetListProductDetail_ByProDelID(int proDelID)
        {
            SqlCommand command = new SqlCommand("Select * from ProductDetail where ProDelID=@proDelID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@proDelID", proDelID);

            return SQLDB.SQLDB.GetData(command);
        }
        public void UpdateProductDetail(int proDelID, int proID, int vCode, string vName, string vDesc, string vContent, string vImage,
            int iQuantity, float vPrice, DateTime createDate, string iView, bool active)
        {
            SqlCommand command = new SqlCommand("Update ProductDetail set ProID=@proID,vCode=@vCode,vName=@vName,vDesc=@vDesc,vContent=@vContent,vImage=@vImage,iQuantity=@iQuantity,vPrice=@vPrice,CreateDate=@createDate,iView=@iView,Active=@active where ProDelID=@proDelID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@proID", proID);
            command.Parameters.AddWithValue("@vCode", vCode);
            command.Parameters.AddWithValue("@vName", vName);
            command.Parameters.AddWithValue("@vDesc", vDesc);
            command.Parameters.AddWithValue("@vContent", vContent);
            command.Parameters.AddWithValue("@vImage", vImage);
            command.Parameters.AddWithValue("@iQuantity", iQuantity);
            command.Parameters.AddWithValue("@vPrice", vPrice);
            command.Parameters.AddWithValue("@createDate", createDate);
            command.Parameters.AddWithValue("@iView", iView);
            command.Parameters.AddWithValue("@active", active);
            command.Parameters.AddWithValue("@proDelID", proDelID);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public void DeleteProductDetail(int proDelID)
        {
            SqlCommand command = new SqlCommand("Delete from ProductDetail where ProDelID=@proDelID");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@proDelID", proDelID);

            SQLDB.SQLDB.ExecuteNoneQuery(command);
        }
        public DataTable GetListProductCategories()
        {
            SqlCommand command = new SqlCommand("Select * from ProductCategories where Active='true' order by vOrder");
            command.CommandType = CommandType.Text;

            return SQLDB.SQLDB.GetData(command);
        }
        
        // New product
        public DataTable GetListNewProduct(int top)
        {
            SqlCommand command = new SqlCommand("Select top " + top + " * from ProductDetail where Active='true' order by CreateDate Desc");
            command.CommandType = CommandType.Text;

            return SQLDB.SQLDB.GetData(command);
        }

        //Good price product
        public DataTable GetListPriceProduct(int top)
        {
            SqlCommand command = new SqlCommand("Select top " + top + " * from ProductDetail where Active='true' order by vPrice Desc");
            command.CommandType = CommandType.Text;

            return SQLDB.SQLDB.GetData(command);
        }
        public DataTable GetProductDetailByProDelID(int proDelID)
        {
            SqlCommand command = new SqlCommand("Select * from ProductDetail where ProDelID=@proDelID and Active='true'");
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@proDelID", proDelID);

            return SQLDB.SQLDB.GetData(command);
        }
    }
}
