using DTO_Layer.RolePermission;
using DTO_Layer.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtFlowManager_DA.RolePermission
{
    public class RolePermissionRepository
    {
        public static int AddRolePermission(RolePermissionDTO RolePermission , string currentUser)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_RolePermission_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = RolePermission.RoleID;

                command.Parameters.Add("@PermissionID", SqlDbType.Int).Value = RolePermission.PermissionID;

                command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 100).Value =
                    (object)currentUser ?? DBNull.Value;

                connection.Open();
                var result = command.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public static List<PermissionSummaryDTO> GetPermissionsByRoleID(int roleID)
        {

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_RolePermission_GetByRoleID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    int permissionIDIndex = reader.GetOrdinal("PermissionID");
                    int permissionNameIndex = reader.GetOrdinal("PermissionName");
                    int descriptionIndex = reader.GetOrdinal("Description");

                    var permissions = new List<PermissionSummaryDTO>();

                    while(reader.Read())
                    {
                        string description = reader.IsDBNull(descriptionIndex)
                            ? null
                            : reader.GetString(descriptionIndex);

                        permissions.Add(new PermissionSummaryDTO(
                            reader.GetInt32(permissionIDIndex),
                            reader.GetString(permissionNameIndex),
                            description
                        ));
                    }

                    return permissions;
                }
            }
            }


        public static List<RoleSummaryDTO> GetRolesByPermissionID(int permissionID)
        {

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_RolePermission_GetByPermissionID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PermissionID", SqlDbType.Int).Value = permissionID;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    int roleIDIndex = reader.GetOrdinal("RoleID");
                    int roleNameIndex = reader.GetOrdinal("RoleName");
                    int descriptionIndex = reader.GetOrdinal("Description");

                    var roles = new List<RoleSummaryDTO>();

                    while (reader.Read())
                    {
                        string description = reader.IsDBNull(descriptionIndex)
                            ? null
                            : reader.GetString(descriptionIndex);

                        roles.Add(new RoleSummaryDTO(
                            reader.GetInt32(roleIDIndex),
                            reader.GetString(roleNameIndex),
                            description
                        ));
                    }

                    return roles;
                }
            }
        }


        public static bool RemoveRolePermission(int roleID, int permissionID, string currentUser)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_RolePermission_Remove", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                command.Parameters.Add("@PermissionID", SqlDbType.Int).Value = permissionID;
                command.Parameters.Add("@PerformedBy", SqlDbType.NVarChar, 100).Value = currentUser;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


    }
    
}
