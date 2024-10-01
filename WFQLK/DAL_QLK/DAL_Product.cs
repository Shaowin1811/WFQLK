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
    public class DAL_Product:DBConnect
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetProduct()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dtProduct = new DataTable();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.CommandText = "ListProduct";
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Connection = _conn;
            da.Fill(dtProduct);
            return dtProduct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        public Product_Details GetProductDetails(int status,string searchStr)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            Product_Details dt = new Product_Details();
            cmd = new SqlCommand("SP_ListProduct_Detail", _conn);
            cmd.Parameters.Add(new SqlParameter("@Status", status));
            cmd.Parameters.Add(new SqlParameter("@SearchStr", searchStr));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt.__tblProduct_Details);
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchStr"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public DataTable GetProduct_keyStr(string searchStr, int status)
        {
         
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dtProduct = new DataTable();
            //SqlCommand cmd = new SqlCommand();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            cmd = new SqlCommand("SP_SearchProduct_BySearchKey", _conn);
            cmd.Parameters.Add(new SqlParameter("@SearchStr", searchStr));
            cmd.Parameters.Add(new SqlParameter("@Status", status));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {

			string strQuery = "SELECT * FROM Product Where ProductID= +" + id + ";";
            SqlDataAdapter dt = new SqlDataAdapter(strQuery, _conn);
            Product dtProduct = new Product();
            dt.Fill(dtProduct.tblProduct);
            return dtProduct;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="supplierID"></param>
        /// <param name="productName"></param>
        /// <param name="unit"></param>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <param name="createDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="createdBy"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateProduct(int categoryID, int supplierID, string productName, string unit, int id, string price, DateTime createDate, DateTime updateDate, string createdBy, int status)
        {
            _conn.Open();
			string strQuery = "UPDATE Product SET CategoryID=" + categoryID + ", SupplierID=" + supplierID + " ,ProductName = N'" + productName + "', Unit = '" + unit + "', Price ='" + price + "', CreateDate = '" + createDate + "', UpdateDate = '" + updateDate + "', CreatedBy = N'" + createdBy + "', Status = " + status + " WHERE ProductID = " + id + ";";
            SqlDataAdapter dt = new SqlDataAdapter();
            dt.InsertCommand = new SqlCommand(strQuery, _conn);
            dt.InsertCommand.ExecuteNonQuery();
            return true;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteProduct(int id)
        {
            _conn.Open();
			string strQuery = "DELETE FROM Product where ProductID=+" + id + ";";
            SqlDataAdapter dt = new SqlDataAdapter();
            dt.InsertCommand = new SqlCommand(strQuery, _conn);
            dt.InsertCommand.ExecuteNonQuery();
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="supplierID"></param>
        /// <param name="productName"></param>
        /// <param name="unit"></param>
        /// <param name="price"></param>
        /// <param name="createDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="createdBy"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool CreateProduct(int categoryID,int supplierID, string productName, string unit, string price, DateTime createDate, DateTime updateDate, string createdBy, int status)
        {
            _conn.Open();
            string strQuery = "INSERT INTO Product (CategoryID, SupplierID, ProductName , Unit , Price , CreateDate, UpdateDate , CreatedBy , Status ) VALUES("+categoryID+", "+supplierID+",N'"+productName+"',N'"+unit+"',"+price+",' "+createDate+"', '"+updateDate+"', N'"+createdBy+"',"+status+"); ";
            SqlDataAdapter dt = new SqlDataAdapter();
            //SqlDataAdapter dt = new SqlDataAdapter(strQuery, _conn);
            dt.InsertCommand = new SqlCommand(strQuery, _conn);
            dt.InsertCommand.ExecuteNonQuery();
            //DataTable dtProduct = new DataTable();
            //dt.Fill(dtProduct);
           
            return true;
        }
    }

}
