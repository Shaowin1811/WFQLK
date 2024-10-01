using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLK;
namespace DAL_QLK
{
	public class DAL_Categori : DBConnect
	{

		#region Method

		#region GetCategori

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Category GetCategori()
		{
			SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Category", _conn);
			Category dtCategori = new Category();
			da.Fill(dtCategori.tblCategory);
			return dtCategori;
		}

		#endregion

		#region GetCategoryDetails

		/// <summary>
		/// 
		/// </summary>
		/// <param name="searchStr"></param>
		/// <returns></returns>
		public Category_Detais GetCategoryDetails(string searchStr)
		{
			SqlCommand cmd = new SqlCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			Category_Detais dt = new Category_Detais();
			cmd = new SqlCommand("SP_ListCategory_Detail", _conn);
			cmd.Parameters.Add(new SqlParameter("@SearchStr", searchStr));
			cmd.CommandType = CommandType.StoredProcedure;
			da.SelectCommand = cmd;
			da.Fill(dt.tbl_Category_Details);
			return dt;
		}

		#endregion

		#region GetCategoriById

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Category GetCategoriById(int id)
		{

			string strQuery = "SELECT * FROM Category Where CategoryID= "+id+";";
			SqlDataAdapter dt = new SqlDataAdapter(strQuery, _conn);
			Category dtCategori = new Category();
			dt.Fill(dtCategori.tblCategory);
			return dtCategori;
		}

		#endregion

		#region UpdateCategory

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="categoryName"></param>
		/// <param name="description"></param>
		/// <param name="createDate"></param>
		/// <param name="updateDate"></param>
		/// <param name="createdBy"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public bool UpdateCategory(int id, string categoryName, string description, DateTime createDate, DateTime updateDate, string createdBy, int status)
		{
			_conn.Open();
			string strQuery = "UPDATE Category SET CategoryName=N'" + categoryName + "' ,Description = N'" + description + "', CreateDate = '" + createDate + "', UpdateDate = '" + updateDate + "', CreaterBy = N'" + createdBy + "', Status = " + status + " WHERE CategoryID = " + id + ";";
			SqlDataAdapter dt = new SqlDataAdapter();
			dt.InsertCommand = new SqlCommand(strQuery, _conn);
			dt.InsertCommand.ExecuteNonQuery();
			return true;

		}

		#endregion

		#region DeleteCtegory

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteCtegory(int id)
		{
			_conn.Open();
			string strQuery = "DELETE FROM Category where CategoryID =" + id + ";";
			SqlDataAdapter dt = new SqlDataAdapter();
			dt.InsertCommand = new SqlCommand(strQuery, _conn);
			dt.InsertCommand.ExecuteNonQuery();
			return true;
		}

		#endregion

		#region GetproductById

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool GetproductById(int id)
		{
			_conn.Open();
			string strQuery = "Select * FROM Product where CategoryID=" + id + ";";
			SqlDataAdapter dt = new SqlDataAdapter(strQuery, _conn);
			DataTable dtProduct = new DataTable();
			dt.Fill(dtProduct);
			return dtProduct.Rows.Count > 0;

		}

		#endregion

		#region

		/// <summary>
		/// 
		/// </summary>
		/// <param name="categoryName"></param>
		/// <param name="description"></param>
		/// <param name="createDate"></param>
		/// <param name="updateDate"></param>
		/// <param name="createdBy"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public bool CreateCategory(string categoryName, string description, DateTime createDate, DateTime updateDate, string createdBy, int status)
		{
			_conn.Open();
			string strQuery = "INSERT INTO Category (CategoryName, Description, CreateDate, UpdateDate , CreaterBy , Status ) VALUES(N'"+categoryName+"', N'"+description+"','"+createDate+"', '"+updateDate+"', N'"+createdBy+"',"+status+"); ";
			SqlDataAdapter dt = new SqlDataAdapter();
			dt.InsertCommand = new SqlCommand(strQuery, _conn);
			dt.InsertCommand.ExecuteNonQuery();

			return true;
		}

		#endregion

		#endregion

	}
}
