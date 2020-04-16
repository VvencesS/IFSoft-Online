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
    }
}
