using DTO_Layer.Permissions;
using DTO_Layer.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtFlowManager_DA.Roles
{
    public class RoleRepository
    {

        public static int AddRole(RoleDTO role)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Role_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@RoleName", SqlDbType.NVarChar, 100).Value = role.RoleName;

                command.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value =
                    (object)role.Description ?? DBNull.Value;

                command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 100).Value =
                    (object)role.CreatedBy ?? DBNull.Value;

                connection.Open();
                var result = command.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public static bool UpdateRole(RoleDTO role, string currentUser)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Role_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = role.RoleID;

                command.Parameters.Add("@RoleName", SqlDbType.NVarChar, 100).Value = role.RoleName;

                command.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value =
                    (object)role.Description ?? DBNull.Value;

                command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 100).Value =
                    (object)currentUser ?? DBNull.Value;


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        public static List<RoleDTO> GetAllRoles()
        {
            var roles = new List<RoleDTO>();

            using (SqlConnection conn = new SqlConnection(DataAccessSettings.ConnectionString))
            {


                using (SqlCommand cmd = new SqlCommand("SP_Role_GetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int roleIDIndex = reader.GetOrdinal("RoleID");

                        int roleNameIndex = reader.GetOrdinal("RoleName");
                        int descriptionIndex = reader.GetOrdinal("Description");
                        

                        int createdAtIndex = reader.GetOrdinal("CreatedAt");
                        int isActiveIndex = reader.GetOrdinal("IsActive");
                        int createdByIndex = reader.GetOrdinal("CreatedBy");


                        while (reader.Read())
                        {
                            string description = reader.IsDBNull(descriptionIndex)
                                ? null
                                : reader.GetString(descriptionIndex);


                            roles.Add(new RoleDTO(
                                reader.GetInt32(roleIDIndex),
                                reader.GetString(roleNameIndex),
                                description,
                                reader.GetDateTime(createdAtIndex),
                                reader.GetBoolean(isActiveIndex),
                                reader.GetString(createdByIndex)
                            ));
                        }
                    }
                }
            }

            return roles;
        }


        public static RoleDTO GetRoleByID(int roleID)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Role_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    int roleIDIndex = reader.GetOrdinal("RoleID");

                    int roleNameIndex = reader.GetOrdinal("RoleName");
                    int descriptionIndex = reader.GetOrdinal("Description");


                    int createdAtIndex = reader.GetOrdinal("CreatedAt");
                    int isActiveIndex = reader.GetOrdinal("IsActive");
                    int createdByIndex = reader.GetOrdinal("CreatedBy");

                    if (reader.Read())
                    {
                        string description = reader.IsDBNull(descriptionIndex)
                                ? null
                                : reader.GetString(descriptionIndex);

                        return new RoleDTO(
                                reader.GetInt32(roleIDIndex),
                                reader.GetString(roleNameIndex),
                                description,
                                reader.GetDateTime(createdAtIndex),
                                reader.GetBoolean(isActiveIndex),
                                reader.GetString(createdByIndex)
                            );
                    }
                    else
                        return null;
                }
            }
        }


        public static bool DeactivateRole(int roleID, string currentUser)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Role_Deactivate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 100).Value = currentUser;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        public static bool ReactivateRole(int roleID, string currentUser)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Role_Reactivate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 100).Value = currentUser;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


    }
}
