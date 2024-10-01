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
	public class DAL_Account : DBConnect
	{

		#region Method

		#region GetAccount

		/// <summary>
		/// Lấy danh sách tài khoản
		/// </summary>
		/// <returns>dtUser: trả về danh sách tài kiểu kiểu Datatble</returns>
		public DataTable GetAccount()
		{
			SqlDataAdapter Us = new SqlDataAdapter("SELECT * FROM Account", _conn);
			DataTable dtUser = new DataTable();
			Us.Fill(dtUser);
			return dtUser;
		}

		#endregion

		#region GetAccountById

		/// <summary>
		/// Lấy sanh sách tài khoản theo ID
		/// </summary>
		/// <returns></returns>
		public Account GetAccountById(int id)
		{
			SqlDataAdapter Us = new SqlDataAdapter("SELECT * FROM Account where UserID="+id+";", _conn);
			Account dtUser = new Account();
			Us.Fill(dtUser.tblAccount);
			return dtUser;
		}

		#endregion

		#region GetDataGirlView

		/// <summary>
		///  Lấy danh sách tài khoản
		/// </summary>
		/// <returns> dtAccount: trả về sanh sách tài kiểu kiểu DataSet</returns>
		public Account GetDataGirlView()
		{
			SqlDataAdapter dt = new SqlDataAdapter("SELECT * FROM Account", _conn);
			Account dtAccount = new Account();
			dt.Fill(dtAccount.tblAccount);
			return dtAccount;
		}

		#endregion

		#region Login

		/// <summary>
		/// Kiểm tra đăng nhập
		/// </summary>
		/// <returns>true: nếu dtAccount có dữ liệu, false: nếu dtAccount null</returns>
		public bool Login( string username, string password )
		{
			string strQuery = "Select * from Account where UserName = N'" + username + "' AND PassWord = N'" + password + "'";
			SqlDataAdapter dt = new SqlDataAdapter(strQuery, _conn);
			DataTable dtAccount = new DataTable();
			dt.Fill(dtAccount);
			return dtAccount.Rows.Count > 0;
		}

		#endregion

		#region CreateAccount

		/// <summary>
		/// Thêm mới một tài khoản
		/// </summary>
		/// <param name="userName"> Tên đăng nhập là chuỗ string</param>
		/// <param name="passWord"> Mật khẩu là chuỗi string</param>
		/// <returns></returns>
		public bool CreateAccount( string userName, string passWord )
		{
			_conn.Open();
			string strQuery = "INSERT INTO Account ( UserName, PassWord) VALUES('" + userName + "', '" + passWord + "');";
			SqlDataAdapter dt = new SqlDataAdapter();
			dt.InsertCommand = new SqlCommand(strQuery, _conn);
			dt.InsertCommand.ExecuteNonQuery();
			return true;
		}

		#endregion

		#region UpdateAccount

		/// <summary>
		/// Update thông tin tài khoản
		/// </summary>
		/// <param name="id">id của tài khoản cần Update</param>
		/// <param name="userName">Tên đăng nhập cần thay đổi</param>
		/// <param name="passWord">Mật khẩu cần thay đổi</param>
		/// <returns></returns>
		public bool UpdateAccount( int id, string userName, string passWord )
		{
			_conn.Open();
			string strQuery = "UPDATE Account SET UserName='" + userName + "' ,PassWord = '" + passWord + "' WHERE UserID = " + id + ";";
			SqlDataAdapter dt = new SqlDataAdapter();
			dt.InsertCommand = new SqlCommand(strQuery, _conn);
			dt.InsertCommand.ExecuteNonQuery();
			return true;

		}

		#endregion

		#region DeleteAccount

		/// <summary>
		/// Xóa tài khoảng User
		/// </summary>
		/// <param name="id">id của tài khoản cần xóa</param>
		/// <returns></returns>
		public bool DeleteAccount(int id)
		{
			_conn.Open();
			string strQuery = "DELETE FROM Account where UserID=" + id + ";";
			SqlDataAdapter dt = new SqlDataAdapter();
			dt.InsertCommand = new SqlCommand(strQuery, _conn);
			dt.InsertCommand.ExecuteNonQuery();
			return true;
		}

		#endregion

		#endregion
	}
}
