using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLK;
using DTO_QLK;

namespace BUS_QLK
{
	public class BUS_Account
	{
		DAL_Account dalAccount = new DAL_Account();

		#region Method

		#region GetAccount

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public DataTable GetAccount()
		{
			return dalAccount.GetAccount();
		}

		#endregion

		#region GetAccountById

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Account GetAccountById(int id)
		{
			return dalAccount.GetAccountById(id);
		}

		#endregion

		#region GetDataGirlView

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Account GetDataGirlView()
		{
			return dalAccount.GetDataGirlView();
		}

		#endregion

		#region Getlogin

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="passWord"></param>
		/// <returns></returns>
		public bool Getlogin( string userName, string passWord )
		{
			return dalAccount.Login(userName, passWord); ;

		}

		#endregion

		#region CreateAccount

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="passWord"></param>
		/// <returns></returns>
		public bool CreateAccount( string userName, string passWord )
		{
			dalAccount.CreateAccount(userName, passWord);
			return true;
		}

		#endregion

		#region UpdateAccount

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="userName"></param>
		/// <param name="passWord"></param>
		/// <returns></returns>
		public bool UpdateAccount( int id, string userName, string passWord )
		{
			dalAccount.UpdateAccount(id, userName, passWord);
			return true;
		}

		#endregion

		#region DeleteAccount

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteAccount( int id )
		{
			dalAccount.DeleteAccount(id);
			return true;

		}

		#endregion

		#endregion
	}
}
