using DTO_Layer.UserRole;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtFlowManager_DA.UserRole
{
    public class UserRoleRepository
    {
        public static bool AddUserRole(int userID, int roleID, string currentUser)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_UserRole_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100).Value = currentUser;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public static bool RemoveUserRole(int userID, int roleID, string currentUser)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_UserRole_Remove", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100).Value = currentUser;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }


        public static List<UserRoleUserDTO> GetUsersByRoleID(int roleID)
        {
            var users = new List<UserRoleUserDTO>();

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_UserRole_GetByRoleID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    int userIDIndex = reader.GetOrdinal("UserID");
                    int usernameIndex = reader.GetOrdinal("Username");
                    int roleIDIndex = reader.GetOrdinal("RoleID");

                    while (reader.Read())
                    {
                        users.Add(new UserRoleUserDTO(
                            reader.GetInt32(userIDIndex),
                            reader.GetString(usernameIndex),
                            reader.GetInt32(roleIDIndex)
                        ));
                    }
                }
            }

            return users;
        }

        public static List<UserRoleRoleDTO> GetRolesByUserID(int userID)
        {
            var roles = new List<UserRoleRoleDTO>();

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_UserRole_GetByUserID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    int userIDIndex = reader.GetOrdinal("UserID");
                    int roleIDIndex = reader.GetOrdinal("RoleID");
                    int roleNameIndex = reader.GetOrdinal("RoleName");

                    while (reader.Read())
                    {
                        roles.Add(new UserRoleRoleDTO(
                            reader.GetInt32(userIDIndex),
                            reader.GetInt32(roleIDIndex),
                            reader.GetString(roleNameIndex)
                        ));
                    }
                }
            }

            return roles;
        }
    }
}
