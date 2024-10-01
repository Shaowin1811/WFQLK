using DTO_QLK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLK
{
    public class DAL_Supplier: DBConnect
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Supplier GetSupplier()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Supplier", _conn);
            Supplier dt = new Supplier();
            da.Fill(dt.tblSupplier);
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetSupplierBy(int id)
        {
			SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Supplier  WHERE SupplierID= " + id + ";", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
