using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLK
{
    public class DBConnect
    {
		protected SqlConnection _conn = new SqlConnection( @"Data Source=localhost;Initial Catalog=WFQLK;Integrated Security=True;" );
    }
}
