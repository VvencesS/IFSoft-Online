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
        public DataTable GetListProductCategories()
        {
            SqlCommand command = new SqlCommand("Select * from ProductCategories where Active='true' order by vOrder");
            command.CommandType = CommandType.Text;

            return SQLDB.SQLDB.GetData(command);
        }
    }
}
