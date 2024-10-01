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
	public class BUS_Categori
	{
		DAL_Categori dalCategri = new DAL_Categori();

		#region Method

		#region GetCategori

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Category GetCategori()
		{
			return dalCategri.GetCategori();
		}

		#endregion

		//public DataTable GetCategori()
		//{
		//    return dalCategri.GetCategori();
		//}

		#region GetCategoryDetails

		/// <summary>
		/// 
		/// </summary>
		/// <param name="searchStr"></param>
		/// <returns></returns>
		public Category_Detais GetCategoryDetails( string searchStr )
		{
			return dalCategri.GetCategoryDetails(searchStr);
		}

		#endregion

		#region GetCategoribyId

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Category GetCategoribyId( int id )
		{
			return dalCategri.GetCategoriById(id);
		}

		#endregion

		#region CreateCategory

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
		public bool CreateCategory( string categoryName, string description, DateTime createDate
								 , DateTime updateDate, string createdBy, int status )
		{
			dalCategri.CreateCategory(categoryName, description, createDate, updateDate, createdBy, status);
			return true;
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
		public bool UpdateCategory( int id, string categoryName, string description, DateTime createDate
								 , DateTime updateDate, string createdBy, int status )
		{
			return dalCategri.UpdateCategory(id, categoryName, description, createDate, updateDate, createdBy, status);
		}

		#endregion

		#region DeleteCategory

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteCategory( int id )
		{
			dalCategri.DeleteCtegory(id);
			return true;
		}

		#endregion

		#region GetproductById
		public bool GetproductById( int id )
		{
			return dalCategri.GetproductById(id);
		}

		#endregion

		#endregion
	}
}
