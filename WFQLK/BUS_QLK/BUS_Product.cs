using DAL_QLK;
using DTO_QLK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLK
{
	public class BUS_Product
	{
		DAL_Product dalProduct = new DAL_Product();

		#region Method

		#region GetProduct

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public DataTable GetProduct()
		{
			return dalProduct.GetProduct();
		}

		#endregion

		#region GetProductDetails

		/// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <param name="searchStr"></param>
		/// <returns></returns>
		public Product_Details GetProductDetails( int status, string searchStr )
		{
			return dalProduct.GetProductDetails(status, searchStr);
		}

		#endregion

		#region GetProduct_keyStr

		/// <summary>
		/// 
		/// </summary>
		/// <param name="searchStr"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public DataTable GetProduct_keyStr( string searchStr, int status )
		{
			return dalProduct.GetProduct_keyStr(searchStr, status);
		}

		#endregion

		#region GetProductbyId

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Product GetProductbyId( int id )
		{
			return dalProduct.GetProductById(id);
		}

		#endregion

		#region CreateProduct

		/// <summary>
		/// 
		/// </summary>
		/// <param name="categoryID"></param>
		/// <param name="supplierID"></param>
		/// <param name="productname"></param>
		/// <param name="unit"></param>
		/// <param name="price"></param>
		/// <param name="createDate"></param>
		/// <param name="updateDate"></param>
		/// <param name="createdBy"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public bool CreateProduct( int categoryID, int supplierID, string productname, string unit, string price
								 , DateTime createDate, DateTime updateDate, string createdBy, int status )
		{
			dalProduct.CreateProduct(categoryID, supplierID, productname, unit, price, createDate, updateDate, createdBy, status);
			return true;
		}

		#endregion

		#region UpdateProduct

		/// <summary>
		/// 
		/// </summary>
		/// <param name="categoryID"></param>
		/// <param name="supplierID"></param>
		/// <param name="productname"></param>
		/// <param name="unit"></param>
		/// <param name="id"></param>
		/// <param name="price"></param>
		/// <param name="createDate"></param>
		/// <param name="updateDate"></param>
		/// <param name="createdBy"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public bool UpdateProduct( int categoryID, int supplierID, string productname, string unit, int id, string price
								 , DateTime createDate, DateTime updateDate, string createdBy, int status )
		{
			return dalProduct.UpdateProduct(categoryID, supplierID, productname, unit, id, price, createDate, updateDate, createdBy, status);
		}

		#endregion

		#region DeleteProduct

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteProduct( int id )
		{
			dalProduct.DeleteProduct(id);
			return true;

		}

		#endregion

		#endregion
	}
}
