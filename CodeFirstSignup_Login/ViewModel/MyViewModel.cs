using CodeFirstSignup_Login.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace CodeFirstSignup_Login.ViewModel
{
	public class MyViewModel
	{

	}

	public class AccountViewModel
	{
		public static List<SelectListItem> GetAllRoles(int roleId)
		{
			List<SelectListItem> roles = new List<SelectListItem>();

			using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
			{
				using (SqlCommand cmd = new SqlCommand("usp_RolesGetRolesByRoleId", conn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					conn.Open();

					cmd.Parameters.AddWithValue("@RoleId", roleId);

					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						SelectListItem item = new SelectListItem();
						item.Value = reader["RoleName"].ToString();
						item.Text = reader["RoleName"].ToString();

						roles.Add(item);
					}
				}
			}

			return roles;
		}

		public static UserProfile GetUserProfileData(int currentUserId)
		{
			UserProfile userProfile = new UserProfile();

			using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
			{
				using (SqlCommand cmd = new SqlCommand("usp_UsersGetUserProfileData", conn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					conn.Open();

					cmd.Parameters.AddWithValue("@UserId", currentUserId);

					SqlDataReader reader = cmd.ExecuteReader();

					reader.Read();

					userProfile.FullName = reader["FullName"].ToString();
					userProfile.Email = reader["Email"].ToString();
					userProfile.Address = reader["Address"].ToString();

				}
			}

			return userProfile;
		}

		public static void UpdateUserProfile(UserProfile userProfile)
		{
			using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
			{
				using (SqlCommand cmd = new SqlCommand("usp_UsersUpdateUserProfile", conn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					conn.Open();

					cmd.Parameters.AddWithValue("@UserId", WebSecurity.CurrentUserId);
					cmd.Parameters.AddWithValue("@FullName", userProfile.FullName);
					cmd.Parameters.AddWithValue("@Email", userProfile.Email);
					cmd.Parameters.AddWithValue("@Address", userProfile.Address);

					cmd.ExecuteNonQuery();
				}
			}
		}
	}


}