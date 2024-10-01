using BUS_QLK;
using DTO_QLK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GUI_QLK
{
	public partial class fQLK : Form
	{
		#region Biến toàn cục

		/// <summary>
		/// công dụng biến
		/// </summary>
		private bool isThoat = true;

		/// <summary>
		/// mô tả về biến
		/// </summary>
		private string strNhan;

		/// <summary>
		/// nhận giá trị combobox
		/// </summary>
		private string pro_Cb_SelectValue = string.Empty;

		#endregion

		#region Constant

		private string MSG_CanNotAddUser = "Không thể thêm mới tài khoản";
		private string MSG_SuccessAddUser = "Thêm mới tài khoản thành công";
		private string MSG_SuccessUpdatePassWord = "Đổi mật khẩu thành công";
		private string MSG_ErrorUpdatePassWord = "Đổi mật khẩu thất bại";
		private string MSG_CanNotUpdatePassWord = "Không thể đổi mật khẩu";
		private string MSG_SuccessUpdate = "Sửa thành công";
		private string MSG_ErrorUpdate = "Sửa không thành công";
		private string MSG_SuccessDelete = "Xóa thành công";
		private string MSG_ErrorDelete = "Xóa không thành công";
		private string MSG_CanNotDelete = "Không được xóa";
		private string MSG_SuccessAdd = "Thêm thành công";
		private string MSG_ErrorAdd = "Thêm không thành công";
		private string MSG_Error = "Ops! Lỗi rồi.";
		private string MSG_NOTIF = "Thông báo";
		private string ErrorReEnteredpPassword = "Mật khẩu nhập lại không đúng!";
		private string MSG_Logout = "Bạn muốn đăng xuất ?";
		private string MSG_CategoryName = " Vui lòng nhập tên loại mặt hàng";
		private string MSG_CreatedBy = "Vui lòng nhập người tạo";
		private string MSG_Status = "Vui lòng nhập trạng thái";
		private string MSG_Unit = "Vui lòng nhập đơn vị tính";
		private string MSG_Price = "Vui lòng nhập giá";
		private string MSG_ProductName = "Vui lòng nhập tên mặt hàng";
		private string MSG_SelectedSuppleir = "Vui lòng chọn nhà cung cấp";
		private string MSG_SelectedCategory = "Vui lòng chọn loại mặt hàng";
		private string MSG_Export = "Xuất dữ liệu ra Excel thành công!";
		#endregion

		#region Contructor

		#region fQLK

		/// <summary>
		/// 
		/// </summary>
		public fQLK()
		{
			InitializeComponent();
			btnUpdate.Enabled = false;
			btnDelete.Enabled = false;
			btnUpdate_Cate.Enabled = false;
			btnDelete_Cate.Enabled = false;
			btnUpdate_User.Enabled = false;
			btnDelete_User.Enabled = false;
		}

		#endregion

		#region fQLK : Nhận giá trị UserName từ Flogin

		/// <summary>
		/// 
		/// </summary>
		/// <param name="giatrinhan"></param>
		public fQLK(string giatrinhan) : this()
		{
			strNhan = giatrinhan;
			labName.Text = strNhan;
		}
		#endregion

		#endregion

		#region Event

		#region
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fQLK_Load(object sender, EventArgs e)
		{
			try
			{
				string searchStr = tbTimKiem.Text;

				dtpkCreate.Value = DateTime.Now;
				dtpkUpdate.Value = DateTime.Now;

				dtgvProduct.ReadOnly = true;
				BUS_Account a = new BUS_Account();

				//Account dt = a.GetDataGirlView();
				//dtgvAccount.DataSource = dt.tblAccount;
				DataTable dt = a.GetAccount();
				dtgvAccount.DataSource = dt;

				//
				BUS_Product p = new BUS_Product();
				Product_Details dtpro = p.GetProductDetails(-1, tbSearch.Text);
				dtgvProduct.DataSource = dtpro.__tblProduct_Details;

				//
				BUS_Categori _c = new BUS_Categori();
				Category_Detais dtCate = _c.GetCategoryDetails(searchStr);
				dtgvCategori.DataSource = dtCate.tbl_Category_Details;

				// Xổ dữ liệu vào combobox vùng tìm kiếm
				cbMaLH.DataSource = BindComboboxDs().tblCategory;
				cbMaLH.DisplayMember = "CategoryName";
				cbMaLH.ValueMember = "CategoryID";
				cbMaLH.SelectedIndex = 0;

				// Xổ dữ liệu vào combobox Category Vùng thông tin 
				//cbCategori.DataSource = BindComboboxDs().tblCategory;
				//cbCategori.DisplayMember = "CategoryName";
				//cbCategori.ValueMember = "CategoryID";
				//cbCategori.SelectedIndex = 0;

				// Xổ dữ liệu vào combobox supplier
				cbMaNCC.DataSource = bindComboboxSupplierDs().tblSupplier;
				cbMaNCC.DisplayMember = "SupplierName";
				cbMaNCC.ValueMember = "SupplierID";
				cbMaNCC.SelectedIndex = 0;


				cb_Status_Search.DataSource = GetStatusList();
				cb_Status_Search.DisplayMember = "name";
				cb_Status_Search.ValueMember = "id";
				cb_Status_Search.SelectedIndex = 0;

				cb_Pro_Status.DataSource = GetStatusList();
				cb_Pro_Status.DisplayMember = "name";
				cb_Pro_Status.ValueMember = "id";
				cb_Pro_Status.SelectedIndex = 0;

				Cb_Status_Cate.DataSource = GetStatusList();
				Cb_Status_Cate.DisplayMember = "name";
				Cb_Status_Cate.ValueMember = "id";
				Cb_Status_Cate.SelectedIndex = 0;


			}
			catch (Exception ex)
			{
				MessageBox.Show(MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}
		}
		#endregion

		#region fQLK_FormClosing : Sự kiến exit FQLK

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fQLK_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (isThoat)
				Application.Exit();
		}

		#endregion

		#region dtgvProduct_CellClick : Loading từng dữ liệu lên textbox

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dtgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int pId = Convert.ToInt32(dtgvProduct.CurrentRow.Cells[0].Value.ToString());
				BUS_Product p = new BUS_Product();
				Product dtpro = p.GetProductbyId(pId);
				cbMaLH.SelectedValue = dtpro.tblProduct[0].CategoryID.ToString();
				cbMaNCC.SelectedValue = dtpro.tblProduct[0].SupplierID.ToString();
				tbProductName.Text = dtpro.tblProduct[0].ProductName.ToString();
				tbUnit.Text = dtpro.tblProduct[0].Unit.ToString();
				tbPrice.Text = dtpro.tblProduct[0].Price.ToString();
				dtpkCreate.Value = dtpro.tblProduct[0].CreateDate;
				if (dtpro.tblProduct[0].IsUpdateDateNull())
				{
					dtpkUpdate.Value = DateTime.Now;
				}
				else
				{
					dtpkUpdate.Value = dtpro.tblProduct[0].UpdateDate;
				}
				tbCreatedBy.Text = dtpro.tblProduct[0].CreatedBy.ToString();

				//tbStatus.Text = dtpro.tblProduct[0].Status.ToString();
				cb_Pro_Status.SelectedValue = dtpro.tblProduct[0].Status;
				if (!string.IsNullOrEmpty(pId.ToString()))
				{
					btnUpdate.Enabled = true;
					btnDelete.Enabled = true;
				}
				else
				{
					btnUpdate.Enabled = false;
					btnDelete.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}
		}

		#endregion

		#region btnAdd_Click : Thêm mới một mặt hàng

		/// <summary>
		/// Thêm mới mặt hàng
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (KTThongTin())
			{
				try
				{
					int categoriId = Convert.ToInt32(cbMaLH.SelectedValue);
					int supplierId = Convert.ToInt32(cbMaNCC.SelectedValue);
					string productName = tbProductName.Text;
					string unit = tbUnit.Text;
					string price = tbPrice.Text;
					DateTime createDate = dtpkCreate.Value;
					DateTime updateDate =/*default(DateTime);*/ new DateTime(1900, 1, 1);
					string createdBy = tbCreatedBy.Text;
					int status = Convert.ToInt32( pro_Cb_SelectValue );
					BUS_Product p = new BUS_Product();
					if (p.CreateProduct(categoriId, supplierId, productName, unit, price, createDate, updateDate, createdBy, status))
					{

						MessageBox.Show(MSG_SuccessAdd, this.MSG_NOTIF, MessageBoxButtons.OK);
						Product_Details dtpro = p.GetProductDetails(-1, tbSearch.Text);
						dtgvProduct.DataSource = dtpro.__tblProduct_Details;
					}
					else
					{
						MessageBox.Show(MSG_ErrorAdd, this.MSG_NOTIF, MessageBoxButtons.OK);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.YesNo);
				}
			}
		}
		#endregion

		#region btnSearch_Click : Tim kiếm mặt hàng

		/// <summary>
		/// Tìm kiếm mặt hàng theo status và từ khóa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			var searchStr = tbSearch.Text;
			var status = cb_Status_Search.SelectedValue;
			int st = Convert.ToInt32(status);
			BUS_Product p = new BUS_Product();
			Product_Details dtpro = p.GetProductDetails(st, searchStr);
			dtgvProduct.DataSource = dtpro.__tblProduct_Details;
			//dtpro = p.GetProduct_keyStr(searchStr, st);
		}

		#endregion

		#region btnDelete_Click : Sự kiến xóa mặt hàng

		/// <summary>
		/// Xóa mặt hàng theo ProductID
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				int pId = Convert.ToInt32(dtgvProduct.CurrentRow.Cells[0].Value.ToString());
				BUS_Product p = new BUS_Product();
				if (p.DeleteProduct(pId))
				{
					MessageBox.Show(MSG_SuccessDelete, this.MSG_NOTIF, MessageBoxButtons.OK);
					Product_Details dtpro = p.GetProductDetails(-1, tbSearch.Text);
					dtgvProduct.DataSource = dtpro.__tblProduct_Details;
				}
				else
				{
					MessageBox.Show(MSG_ErrorDelete, this.MSG_NOTIF, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}
		}
		#endregion

		#region btnUpdate_Click : Sự kiến Update thông tin sản phẩm

		/// <summary>
		/// Chỉnh sửa thông tin sản phẩm
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				int pId = Convert.ToInt32(dtgvProduct.CurrentRow.Cells[0].Value.ToString());
				BUS_Product p = new BUS_Product();
				int categoriId = Convert.ToInt32(cbMaLH.SelectedValue);
				int supplierId = Convert.ToInt32(cbMaNCC.SelectedValue);
				string productName = tbProductName.Text;
				string unit = tbUnit.Text;
				string price = tbPrice.Text;
				DateTime createDate = dtpkCreate.Value;
				DateTime updateDate = DateTime.Now;
				string createdBy = tbCreatedBy.Text;
				int status = Convert.ToInt32(cb_Pro_Status.SelectedValue);
				if (p.UpdateProduct(categoriId, supplierId, productName, unit, pId, price, createDate, updateDate, createdBy, status))
				{
					MessageBox.Show(MSG_SuccessUpdate, this.MSG_NOTIF, MessageBoxButtons.OK);
					Product_Details dtpro = p.GetProductDetails(-1, tbSearch.Text);
					dtgvProduct.DataSource = dtpro.__tblProduct_Details;
				}
				else
				{
					MessageBox.Show(MSG_ErrorUpdate, this.MSG_NOTIF, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}
		}

		#endregion

		#region dtgvCategori_CellClick : Sự kiện click data

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dtgvCategori_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int cId = Convert.ToInt32(dtgvCategori.CurrentRow.Cells[0].Value.ToString());
				BUS_Categori c = new BUS_Categori();
				Category dtcate = c.GetCategoribyId(cId);
				tb_Cate_CategoryName.Text = dtcate.tblCategory[0].CategoryName.ToString();
				//dtpk_Cate_CreateDate.Value = dtcate.tblCategory[0].CreateDate;
				/*dtpk_Cate_UpdateDate.Value = dtcate.tblCategory[0].UpdateDate*/
				tb_Cate_CreatedBy.Text = dtcate.tblCategory[0].CreaterBy.ToString();
				Cb_Status_Cate.SelectedValue = dtcate.tblCategory[0].Status;
				rtbDescription.Text = dtcate.tblCategory[0].Description.ToString();
				if (dtcate.tblCategory[0].IsCreateDateNull())
				{
					dtpk_Cate_CreateDate.Value = DateTime.Now;
				}
				else
				{
					dtpk_Cate_CreateDate.Value = dtcate.tblCategory[0].CreateDate;
				}
				if (dtcate.tblCategory[0].IsUpdateDateNull())
				{
					dtpk_Cate_UpdateDate.Value = DateTime.Now;
				}
				else
				{
					dtpk_Cate_UpdateDate.Value = dtcate.tblCategory[0].UpdateDate;
				}
				if (!string.IsNullOrEmpty(cId.ToString()))
				{
					btnUpdate_Cate.Enabled = true;
					btnDelete_Cate.Enabled = true;
				}
				else
				{
					btnUpdate_Cate.Enabled = false;
					btnDelete_Cate.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}
		}

		#endregion

		#region btnAdd_Cate_Click : Sự kiện Add Category

		/// <summary>
		/// Thêm mới loại mặt hàng
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Cate_Click(object sender, EventArgs e)
		{
			if (KTThongTinCategory())
			{
				try
				{
					string searchStr = tbTimKiem.Text;
					string categoryName = tb_Cate_CategoryName.Text;
					string description = rtbDescription.Text;
					DateTime createDate = dtpk_Cate_CreateDate.Value;
					DateTime updateDate =/*default(DateTime);*/ new DateTime(1900, 1, 1);
					string createdBy = tb_Cate_CreatedBy.Text;
					int status = Convert.ToInt32(Cb_Status_Cate.SelectedValue);
					BUS_Categori c = new BUS_Categori();
					if (c.CreateCategory(categoryName, description, createDate, updateDate, createdBy, status))
					{

						MessageBox.Show(MSG_SuccessAdd, this.MSG_NOTIF, MessageBoxButtons.OK);
						Category_Detais dtCate = c.GetCategoryDetails(searchStr);
						dtgvCategori.DataSource = dtCate.tbl_Category_Details;
					}
					else
					{
						MessageBox.Show(MSG_ErrorAdd, this.MSG_NOTIF, MessageBoxButtons.OK);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
				}
			}
		}

		#endregion

		#region btnUpdate_Cate_Click : Sự kiện Update thông tin loại mặt hàng

		/// <summary>
		/// Chỉnh sửa thông tin loại mặt hàng
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdate_Cate_Click(object sender, EventArgs e)
		{
			if (KTThongTinCategory())
			{
				try
				{
					string searchStr = tbTimKiem.Text;
					int cId = Convert.ToInt32(dtgvCategori.CurrentRow.Cells[0].Value.ToString());
					string categoryName = tb_Cate_CategoryName.Text;
					string description = rtbDescription.Text;
					DateTime createDate = dtpk_Cate_CreateDate.Value;
					DateTime updateDate = dtpk_Cate_UpdateDate.Value;
					string createdBy = tb_Cate_CreatedBy.Text;
					int status = Convert.ToInt32(Cb_Status_Cate.SelectedValue);
					BUS_Categori c = new BUS_Categori();
					if (c.UpdateCategory(cId, categoryName, description, createDate, updateDate, createdBy, status))
					{
						MessageBox.Show(this.MSG_SuccessUpdate, this.MSG_NOTIF, MessageBoxButtons.OK);
						Category_Detais dtCate = c.GetCategoryDetails(searchStr);
						dtgvCategori.DataSource = dtCate.tbl_Category_Details;
					}
					else
					{
						MessageBox.Show(this.MSG_ErrorUpdate, this.MSG_NOTIF, MessageBoxButtons.OK);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this.MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
				}
			}
		}

		#endregion

		#region btnDelete_Cate_Click : Sự kiện Delete category

		/// <summary>
		/// Delete một loại mặt hàng
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Cate_Click(object sender, EventArgs e)
		{
			try
			{
				string searchStr = tbTimKiem.Text;
				BUS_Categori c = new BUS_Categori();
				int cId = Convert.ToInt32(dtgvCategori.CurrentRow.Cells[0].Value.ToString());
				if (CheckExistProduct(cId) == false)
				{
					if (c.DeleteCategory(cId))
					{
						MessageBox.Show(this.MSG_SuccessDelete, this.MSG_NOTIF, MessageBoxButtons.OK);
						Category_Detais dtCate = c.GetCategoryDetails(searchStr);
						dtgvCategori.DataSource = dtCate.tbl_Category_Details;
					}
					else
					{
						MessageBox.Show(this.MSG_ErrorDelete, this.MSG_NOTIF, MessageBoxButtons.OK);
					}
				}
				else
				{
					MessageBox.Show(this.MSG_CanNotDelete, this.MSG_NOTIF, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}
		}

		#endregion

		#region btnLogout_Click : Sự kiện Logout

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLogout_Click(object sender, EventArgs e)
		{

			isThoat = false;
			if (CheckLogout())
			{
				this.Close();
			}
			//FLogin f = new FLogin();
			//f.ShowDialog();
		}

		#endregion

		#region dtgvAccount_CellClick : sự kiện hiển thị tên User lên textbox khi click vào Datagirdview

		/// <summary>
		/// Hiển thị tên User lên textbox khi click vào Datagirdview
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				BUS_Account a = new BUS_Account();
				int uId = Convert.ToInt32(dtgvAccount.CurrentRow.Cells[0].Value.ToString());
				Account dt = a.GetAccountById(uId);
				tbUserName.Text = dt.tblAccount[0].UserName.ToString();

				//tbPassword.Text = dt.tblAccount[0].PassWord.ToString();
				//tbPassword1.Text = dt.tblAccount[0].PassWord.ToString();
				if (!string.IsNullOrEmpty(uId.ToString()))
				{
					btnDelete_User.Enabled = true;
					btnUpdate_User.Enabled = true;
				}
				else
				{
					btnDelete_User.Enabled = false;
					btnUpdate_User.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}
		}

		#endregion

		#region btnAdd_User_Click() : Sự kiện click thêm mới user

		/// <summary>
		/// Sự kiện click thêm mới user
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_User_Click(object sender, EventArgs e)
		{
			try
			{
				string userName = tbUserName.Text;
				string passWord = tbPassword.Text;
				string passWord1 = tbPassword1.Text;
				BUS_Account a = new BUS_Account();
				if (passWord == passWord1)
				{
					if (a.CreateAccount(userName, GetHash(passWord)))
					{
						MessageBox.Show(this.MSG_SuccessAddUser, this.MSG_NOTIF, MessageBoxButtons.OK);
						Account dt = a.GetDataGirlView();
						dtgvAccount.DataSource = dt.tblAccount;
					}
					else
					{
						MessageBox.Show(this.MSG_CanNotAddUser, this.MSG_NOTIF, MessageBoxButtons.OK);

					}
				}
				else
				{
					MessageBox.Show(this.ErrorReEnteredpPassword, this.MSG_NOTIF, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this.MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}

		}

		#endregion

		#region btnUpdate_User_Click : Sự kiện Update User

		/// <summary>
		///  Thay đổi thông tin User
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdate_User_Click(object sender, EventArgs e)
		{
			try
			{
				string userName = tbUserName.Text;
				string passWord = tbPassword.Text;
				string passWord1 = tbPassword1.Text;
				BUS_Account a = new BUS_Account();
				int aId = Convert.ToInt32(dtgvAccount.CurrentRow.Cells[0].Value.ToString());
				if (passWord == passWord1)
				{
					if (a.UpdateAccount(aId, userName, GetHash(passWord)))
					{
						MessageBox.Show(this.MSG_SuccessUpdatePassWord, this.MSG_NOTIF, MessageBoxButtons.OK);
						Account dt = a.GetDataGirlView();
						dtgvAccount.DataSource = dt.tblAccount;
					}
					else
					{
						MessageBox.Show(this.MSG_CanNotUpdatePassWord, this.MSG_NOTIF, MessageBoxButtons.OK);
					}
				}
				else
				{
					MessageBox.Show(this.MSG_ErrorUpdatePassWord, this.MSG_NOTIF, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this.MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}
		}

		#endregion

		#region  btnDelete_User_Click : Sự kiện xóa một User

		/// <summary>
		///  Xóa một User theo ID
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_User_Click(object sender, EventArgs e)
		{
			try
			{
				BUS_Account a = new BUS_Account();
				int aId = Convert.ToInt32(dtgvAccount.CurrentRow.Cells[0].Value.ToString());
				if (a.DeleteAccount(aId))
				{
					MessageBox.Show(this.MSG_SuccessDelete, this.MSG_NOTIF, MessageBoxButtons.OK);
					Account dt = a.GetDataGirlView();
					dtgvAccount.DataSource = dt.tblAccount;
				}
				else
				{
					MessageBox.Show(this.MSG_CanNotDelete, this.MSG_NOTIF, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this.MSG_Error + ex.Message, this.MSG_NOTIF, MessageBoxButtons.OK);
			}
		}

		#endregion

		#region btnTimkiem_Click : sự kiến tìm kiếm thông tin Category

		/// <summary>
		/// Tìm kiếm thông tin category theo từ khóa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTimkiem_Click(object sender, EventArgs e)
		{
			var searchStr = tbTimKiem.Text;
			BUS_Categori p = new BUS_Categori();
			Category_Detais dtcate = p.GetCategoryDetails(searchStr);
			dtgvCategori.DataSource = dtcate.tbl_Category_Details;
		}

		#endregion

		#region tabAll_Click_1 : Sự kiện loading Combobox
		/// <summary>
		/// Load lại combobox category và combobox Suppleir
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabAll_Click_1(object sender, EventArgs e)
		{
			// Xổ dữ liệu vào combobox vùng tìm kiếm
			cbMaLH.DataSource = BindComboboxDs().tblCategory;
			cbMaLH.DisplayMember = "CategoryName";
			cbMaLH.ValueMember = "CategoryID";
			cbMaLH.SelectedIndex = 0;

			// Xổ dữ liệu vào combobox Category Vùng thông tin 
			//cbCategori.DataSource = BindComboboxDs().tblCategory;
			//cbCategori.DisplayMember = "CategoryName";
			//cbCategori.ValueMember = "CategoryID";
			//cbCategori.SelectedIndex = 0;

			// Xổ dữ liệu vào combobox supplier
			cbMaNCC.DataSource = bindComboboxSupplierDs().tblSupplier;
			cbMaNCC.DisplayMember = "SupplierName";
			cbMaNCC.ValueMember = "SupplierID";
			cbMaNCC.SelectedIndex = 0;

		}
		#endregion

		#region btn_Export_Pro_Click : Export Product

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Export_Pro_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				ToExcel_Product(dtgvProduct, saveFileDialog.FileName);
			}
		}

		#endregion

		#region btn_Excel_Cate_Click : Export Category

		/// <summary>
		/// Export Category
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Excel_Cate_Click( object sender, EventArgs e )
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				ToExcel_Category(dtgvCategori, saveFileDialog.FileName);
			}
		}

		#endregion

		#endregion

		#region Private Method

		#region KTThongTin : Kiểm tra dữ liệu Product

		/// <summary>
		/// Kiểm tra dữ liệu nhập vào khi Add or Update mặt hàng
		/// </summary>
		/// <returns>true: nếu các textbox đẫ được nhập dữ liệu, false: nếu có 1 trong các textbox chưa được nhập dữ liệu</returns>
		public bool KTThongTin()
		{
			if (Convert.ToInt32(cbMaLH.SelectedValue) == -1)
			{
				MessageBox.Show(this.MSG_SelectedCategory, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbMaLH.Focus();
				return false;
			}
			if (Convert.ToInt32(cbMaNCC.SelectedValue) == -1)
			{
				MessageBox.Show(this.MSG_SelectedSuppleir, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbMaNCC.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(tbProductName.Text))
			{
				MessageBox.Show(this.MSG_ProductName, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				tbProductName.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(tbPrice.Text))
			{
				MessageBox.Show(this.MSG_Price, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				tbPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(tbUnit.Text))
			{
				MessageBox.Show(this.MSG_Unit, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				tbUnit.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(tbCreatedBy.Text))
			{
				MessageBox.Show(this.MSG_CreatedBy, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				tbCreatedBy.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(Convert.ToString(cb_Status_Search.SelectedValue)))
			{
				MessageBox.Show(this.MSG_Status, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				cb_Status_Search.Focus();
				return false;
			}
			return true;
		}

		#endregion

		#region GetStatusList() : Danh sách trạng thái sản phẩm

		/// <summary>
		///  Danh sách trạng thái sản phẩm
		/// </summary>
		/// <returns>Trả về danh sách trạng thái</returns>
		public static IList<DTO_Status> GetStatusList()
		{
			return new List<DTO_Status>()
				{
					new DTO_Status() { name ="--Chọn--", id = -1},
					new DTO_Status() { name ="Còn hàng", id = 1 },
					new DTO_Status() { name ="Hết hàng" , id = 0},
					new DTO_Status() { name ="Ngừng bán", id = 2},
				};
		}

		#endregion

		#region kt : Kiểm tra sự tồn tại của Product

		/// <summary>
		/// kiểm tra một tồn tại của một mặt hàng theo ID
		/// </summary>
		/// <param name="id">id sản phẩm</param>
		/// <returns>true:tồn tại sản phẩm có loại mặt hầng với mã mặt hằng = id, false: không tồn tại sản phẩm có loại mặt hầng với mã mặt hằng = id</returns>
		private bool CheckExistProduct(int id)
		{
			BUS_Categori c = new BUS_Categori();
			return c.GetproductById(id);
		}

		#endregion

		#region BindComboboxDs() : Add row mặc địch vào tblCategory

		/// <summary>
		/// Add row mặc địch vào tblCategory
		/// </summary>
		/// <returns>Trả về tblCategory đã được add row mặc định</returns>
		public static Category BindComboboxDs()
		{
			// Khởi tạo dataset chứa data category hiển thị lên combobox
			Category bindComboboxDss = new Category();

			// New row category (row mặc định)
			Category.tblCategoryRow rows = bindComboboxDss.tblCategory.NewtblCategoryRow();

			// Gán giá trị cho row mặc định
			rows.CategoryName = "--Chọn--";
			rows.CategoryID = -1;

			// Add row mặc định vào list
			bindComboboxDss.tblCategory.AddtblCategoryRow(rows);

			// Truy suất data category ở database
			BUS_Categori cs = new BUS_Categori();
			Category categoryDss = cs.GetCategori();

			//dtgvCategori.DataSource = categoryDs;
			foreach (Category.tblCategoryRow item in categoryDss.tblCategory.Rows)
			{
				bindComboboxDss.tblCategory.Rows.Add(item.ItemArray);
			}
			return bindComboboxDss;
		}

		#endregion

		#region bindComboboxSupplierDs() : Add row mặc địch vào tblSupplier

		/// <summary>
		/// Add row mặc địch vào tblSupplier
		/// </summary>
		/// <returns>Trả về tblSupplier đã được add row mặc định</returns>
		public static Supplier bindComboboxSupplierDs()
		{
			// Khởi tạo dataset chứa data supplier hiển thị lên combobox
			Supplier bindComboboxSupplierDs = new Supplier();

			// New row Supplier (row mặc định)
			Supplier.tblSupplierRow rowSuppleir = bindComboboxSupplierDs.tblSupplier.NewtblSupplierRow();

			// Gán giá trị cho row mặc định
			rowSuppleir.SupplierName = "--Chọn--";
			rowSuppleir.SupplierID = -1;

			// Add row mặc định vào list
			bindComboboxSupplierDs.tblSupplier.AddtblSupplierRow(rowSuppleir);
			BUS_Suppleir s = new BUS_Suppleir();
			Supplier dtSup = s.GetSupplier();
			foreach (Supplier.tblSupplierRow item in dtSup.tblSupplier.Rows)
			{
				bindComboboxSupplierDs.tblSupplier.Rows.Add(item.ItemArray);
			}
			return bindComboboxSupplierDs;
		}

		#endregion

		#region GetHash : Mã hóa MD5

		/// <summary>
		///  Mã hóa mật khẩu
		/// </summary>
		/// <param name="plainText"> Là mật khẩu</param>
		/// <returns>strBuilder: Chuỗi string đã được mã hóa</returns>
		public static string GetHash( string plainText )
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			// Compute hash from the bytes of text
			md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));
			// Get hash result after compute it
			byte[] result = md5.Hash;
			StringBuilder strBuilder = new StringBuilder();
			for (int i = 0; i < result.Length; i++)
			{
				strBuilder.Append(result[i].ToString("x2"));
			}
			return strBuilder.ToString();
		}

		#endregion

		#region KTThongTinCategory : Kiểm tra dữ liệu vào của Category

		/// <summary>
		/// Kiểm tra dữ liệu nhập vào khi Add or Update loại mặt hàng
		/// </summary>
		/// <returns></returns>
		public bool KTThongTinCategory()
		{
			if (string.IsNullOrEmpty(tb_Cate_CategoryName.Text))
			{
				MessageBox.Show(this.MSG_CategoryName, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				tb_Cate_CategoryName.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(tb_Cate_CreatedBy.Text))
			{
				MessageBox.Show(this.MSG_CreatedBy, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				tb_Cate_CreatedBy.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(Cb_Status_Cate.SelectedValue.ToString()))
			{
				MessageBox.Show(this.MSG_Status, this.MSG_NOTIF, MessageBoxButtons.OK, MessageBoxIcon.Information);
				Cb_Status_Cate.Focus();
				return false;
			}
			return true;
		}

		#endregion

		#region  tbPrice_KeyPress : Chỉ cho phép nhập số

		/// <summary>
		///  Giá cả chỉ cho phép nhập số
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbPrice_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ))
			{
				e.Handled = true;
			}
			if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
			{
				e.Handled = true;
			}
		}

		#endregion

		#region CheckLogout : Check logout

		/// <summary>
		/// Check logout
		/// </summary>
		/// <returns>false: nếu click button NO, true: Click button Yes</returns>
		/// 
		private bool CheckLogout()
		{
			if (MessageBox.Show( this.MSG_Logout, this.MSG_NOTIF, MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.Yes)
			{
				return true;
			}
			return false;
		}

		#endregion

		#region ToExcel : Xuất excel product

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dtgvProduct"></param>
		/// <param name="fileName"></param>
		private void ToExcel_Product(DataGridView dtgvProduct, string fileName)
		{
			//khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
			Microsoft.Office.Interop.Excel.Application excel;
			Microsoft.Office.Interop.Excel.Workbook workbook;
			Microsoft.Office.Interop.Excel.Worksheet worksheet;
			try
			{
				//Tạo đối tượng COM.
				excel = new Microsoft.Office.Interop.Excel.Application();
				excel.Visible = false;
				excel.DisplayAlerts = false;

				//tạo mới một Workbooks bằng phương thức add()
				workbook = excel.Workbooks.Add(Type.Missing);
				worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];

				//đặt tên cho sheet
				worksheet.Name = "Quản lý kho";

				// export header trong DataGridView
				for (int i = 0; i < dtgvProduct.ColumnCount; i++)
				{
					worksheet.Cells[1, i + 1] = dtgvProduct.Columns[i].HeaderText;
				}

				// export nội dung trong DataGridView
				for (int i = 0; i < dtgvProduct.RowCount; i++)
				{
					for (int j = 0; j < dtgvProduct.ColumnCount; j++)
					{
						worksheet.Cells[i + 2, j + 1] = dtgvProduct.Rows[i].Cells[j].Value.ToString();
					}
				}

				// sử dụng phương thức SaveAs() để lưu workbook với filename
				workbook.SaveAs(fileName);

				//đóng workbook
				workbook.Close();
				excel.Quit();
				MessageBox.Show(MSG_Export);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				workbook = null;
				worksheet = null;
			}
		}

		#endregion

		#region ToExcel : Xuất excel Category

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dtgvProduct"></param>
		/// <param name="fileName"></param>
		private void ToExcel_Category( DataGridView dtgvCategory
									 , string fileName )
		{
			// khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
			Microsoft.Office.Interop.Excel.Application excel;
			Microsoft.Office.Interop.Excel.Workbook workbook;
			Microsoft.Office.Interop.Excel.Worksheet worksheet;
			try
			{
				// Tạo đối tượng COM.
				excel = new Microsoft.Office.Interop.Excel.Application();
				excel.Visible = false;
				excel.DisplayAlerts = false;

				// tạo mới một Workbooks bằng phương thức add()
				workbook = excel.Workbooks.Add(Type.Missing);
				worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];

				//đặt tên cho sheet
				worksheet.Name = "Quản lý kho";

				// export header trong DataGridView
				for (int i = 0; i < dtgvCategory.ColumnCount; i++)
				{
					worksheet.Cells[1, i + 1] = dtgvCategory.Columns[i].HeaderText;
				}

				// export nội dung trong DataGridView
				for (int i = 0; i < dtgvCategory.RowCount; i++)
				{
					for (int j = 0; j < dtgvCategory.ColumnCount; j++)
					{
						worksheet.Cells[i + 2, j + 1] = dtgvCategory.Rows[i].Cells[j].Value.ToString();
					}
				}

				// sử dụng phương thức SaveAs() để lưu workbook với filename
				workbook.SaveAs(fileName);

				// đóng workbook
				workbook.Close();
				excel.Quit();
				MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				workbook = null;
				worksheet = null;
			}
		}

        #endregion

        #endregion

        private void cb_Pro_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
			pro_Cb_SelectValue = cb_Pro_Status.SelectedValue.ToString();
		}
    }
}