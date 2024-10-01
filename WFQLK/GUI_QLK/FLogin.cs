using BUS_QLK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLK
{
	public partial class FLogin : Form
	{

		#region Constant

		#region FLogin
		/// <summary>
		/// FLogin
		/// </summary>
		public FLogin()
		{
			InitializeComponent();
		}

		#endregion

		#endregion

		#region Event

		#region btDangNhap_Click : Sự kiên đăng nhập

		/// <summary>
		/// Sự kiên đăng nhập
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btDangNhap_Click(object sender, EventArgs e)
		{
			string userName = tbUserName.Text;
			string passWord = tbPassWord.Text;
			if (login(userName, passWord))
			{

				fQLK f = new fQLK(userName);
				this.Hide();
				f.ShowDialog();
				this.Show();
			}
			else
			{
				MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.YesNo);
			}
		}

		#endregion

		#region btHuy_Click :  Sự kiến thóa chương trình

		/// <summary>
		///  Sự kiến thóa chương trình
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btHuy_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#endregion

		#region fLogin_FormClosing : Sự kiến thoát chương trình

		/// <summary>
		///  Sự kiến thoát chương trình không làm gì thì hiện thông báo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Thoát chương trình ??", "Thông báo", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
			{
				e.Cancel = true;
			}
		}

		#endregion

		#region login : Sự kiến đăng nhập

		/// <summary>
		/// Sự kiến đăng nhập
		/// </summary>
		/// <param name="username"></param>
		/// <param name="pasworrd"></param>
		/// <returns></returns>
		bool login(string username, string pasworrd)
		{
			BUS_Account p = new BUS_Account();
			return p.Getlogin(username, GetHash(pasworrd));
		}

		#endregion

		#region GetHash : Mã hóa MD5

		/// <summary>
		/// 
		/// </summary>
		/// <param name="plainText"></param>
		/// <returns></returns>
		public static string GetHash(string plainText)
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

		#endregion
	}
}
