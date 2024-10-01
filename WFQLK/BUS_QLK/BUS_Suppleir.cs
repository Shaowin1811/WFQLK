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
	public class BUS_Suppleir
	{
		DAL_Supplier dalSupplier = new DAL_Supplier();

		#region Method

		#region GetSupplier

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Supplier GetSupplier()
		{
			return dalSupplier.GetSupplier();
		}

		#endregion

		#region GetSupplierBy

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public DataTable GetSupplierBy(int id)
		{
			return dalSupplier.GetSupplierBy(id);
		}

		#endregion

		#endregion

	}
}
