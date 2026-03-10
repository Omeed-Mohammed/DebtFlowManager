using DebtFlowManager_DA.Suppliers;
using DTO_Layer.Persons;
using DTO_Layer.Suppliers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtFlowManager_DA.Persons
{
    public class PersonRepository
    {
        public static int AddPerson(PersonDTO person)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Person_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", person.FirstName);

                command.Parameters.AddWithValue("@MiddleName",
                    (object)person.MiddleName ?? DBNull.Value);

                command.Parameters.AddWithValue("@LastName", person.LastName);

                command.Parameters.AddWithValue("@Gender", person.Gender);

                command.Parameters.AddWithValue("@BirthDate",
                    (object)person.BirthDate ?? DBNull.Value);

                command.Parameters.AddWithValue("@NationalNo", person.NationalNo);

                command.Parameters.AddWithValue("@Address",
                    (object)person.Address ?? DBNull.Value);

                command.Parameters.AddWithValue("@Email",
                    (object)person.Email ?? DBNull.Value);

                command.Parameters.AddWithValue("@CreatedBy", person.CreatedBy);

                connection.Open();
                var result = command.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : 0;
            }
        }


        public static bool UpdatePerson(PersonDTO person, string currentUser)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Person_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@PersonID", person.PersonID);

                command.Parameters.AddWithValue("@FirstName", person.FirstName);

                command.Parameters.AddWithValue("@MiddleName",
                    (object)person.MiddleName ?? DBNull.Value);

                command.Parameters.AddWithValue("@LastName", person.LastName);

                command.Parameters.AddWithValue("@Gender", person.Gender);

                command.Parameters.AddWithValue("@BirthDate",
                    (object)person.BirthDate ?? DBNull.Value);

                command.Parameters.AddWithValue("@NationalNo", person.NationalNo);

                command.Parameters.AddWithValue("@Address",
                    (object)person.Address ?? DBNull.Value);

                command.Parameters.AddWithValue("@Email",
                    (object)person.Email ?? DBNull.Value);

                command.Parameters.AddWithValue("@UpdatedBy", currentUser);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        public static List<PersonDTO> GetAllPersons()
        {
            var persons = new List<PersonDTO>();

            using (SqlConnection conn = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                

                using (SqlCommand cmd = new SqlCommand("SP_Person_GetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int personIDIndex = reader.GetOrdinal("PersonID");

                        int firstNameIndex = reader.GetOrdinal("FirstName");
                        int middleNameIndex = reader.GetOrdinal("MiddleName");
                        int lastNameIndex = reader.GetOrdinal("LastName");

                        int genderIndex = reader.GetOrdinal("Gender");

                        int birthDateIndex = reader.GetOrdinal("BirthDate");

                        int nationalNoIndex = reader.GetOrdinal("NationalNo");

                        int addressIndex = reader.GetOrdinal("Address");
                        int emailIndex = reader.GetOrdinal("Email");

                        int createdAtIndex = reader.GetOrdinal("CreatedAt");
                        int createdByIndex = reader.GetOrdinal("CreatedBy");



                        while (reader.Read())
                        {
                            string middleName = reader.IsDBNull(middleNameIndex)
                                ? null
                                : reader.GetString(middleNameIndex);

                            DateTime? birthDate = reader.IsDBNull(birthDateIndex)
                                ? (DateTime?)null
                                : reader.GetDateTime(birthDateIndex);

                            string address = reader.IsDBNull(addressIndex)
                                ? null
                                : reader.GetString(addressIndex);

                            string email = reader.IsDBNull(emailIndex)
                                ? null
                                : reader.GetString(emailIndex);


                            persons.Add(new PersonDTO(
                                reader.GetInt32(personIDIndex),
                                reader.GetString(firstNameIndex),
                                middleName,
                                reader.GetString(lastNameIndex),
                                reader.GetBoolean(genderIndex),
                                birthDate,
                                reader.GetString(nationalNoIndex),
                                address,
                                email,
                                reader.GetDateTime(createdAtIndex),
                                reader.GetString(createdByIndex)
                            ));
                        }
                    }
                }
            }

            return persons;
        }


        public static PersonDTO GetPersonById(int personID)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Person_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", personID);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    int personIDIndex = reader.GetOrdinal("PersonID");

                    int firstNameIndex = reader.GetOrdinal("FirstName");
                    int middleNameIndex = reader.GetOrdinal("MiddleName");
                    int lastNameIndex = reader.GetOrdinal("LastName");

                    int genderIndex = reader.GetOrdinal("Gender");

                    int birthDateIndex = reader.GetOrdinal("BirthDate");

                    int nationalNoIndex = reader.GetOrdinal("NationalNo");

                    int addressIndex = reader.GetOrdinal("Address");
                    int emailIndex = reader.GetOrdinal("Email");

                    int createdAtIndex = reader.GetOrdinal("CreatedAt");
                    int createdByIndex = reader.GetOrdinal("CreatedBy");

                    if (reader.Read())
                    {
                        string middleName = reader.IsDBNull(middleNameIndex)
                               ? null
                               : reader.GetString(middleNameIndex);

                        DateTime? birthDate = reader.IsDBNull(birthDateIndex)
                            ? (DateTime?)null
                            : reader.GetDateTime(birthDateIndex);

                        string address = reader.IsDBNull(addressIndex)
                            ? null
                            : reader.GetString(addressIndex);

                        string email = reader.IsDBNull(emailIndex)
                            ? null
                            : reader.GetString(emailIndex);

                        return new PersonDTO(
                                reader.GetInt32(personIDIndex),
                                reader.GetString(firstNameIndex),
                                middleName,
                                reader.GetString(lastNameIndex),
                                reader.GetBoolean(genderIndex),
                                birthDate,
                                reader.GetString(nationalNoIndex),
                                address,
                                email,
                                reader.GetDateTime(createdAtIndex),
                                reader.GetString(createdByIndex)
                            );
                    }
                    else
                        return null;
                }
            }
        }


        public static PersonDTO GetByNationalNo(string nationalNo)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Person_GetByNationalNo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NationalNo", nationalNo);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    int personIDIndex = reader.GetOrdinal("PersonID");

                    int firstNameIndex = reader.GetOrdinal("FirstName");
                    int middleNameIndex = reader.GetOrdinal("MiddleName");
                    int lastNameIndex = reader.GetOrdinal("LastName");

                    int genderIndex = reader.GetOrdinal("Gender");

                    int birthDateIndex = reader.GetOrdinal("BirthDate");

                    int nationalNoIndex = reader.GetOrdinal("NationalNo");

                    int addressIndex = reader.GetOrdinal("Address");
                    int emailIndex = reader.GetOrdinal("Email");

                    int createdAtIndex = reader.GetOrdinal("CreatedAt");
                    int createdByIndex = reader.GetOrdinal("CreatedBy");

                    if (reader.Read())
                    {
                        string middleName = reader.IsDBNull(middleNameIndex)
                               ? null
                               : reader.GetString(middleNameIndex);

                        DateTime? birthDate = reader.IsDBNull(birthDateIndex)
                            ? (DateTime?)null
                            : reader.GetDateTime(birthDateIndex);

                        string address = reader.IsDBNull(addressIndex)
                            ? null
                            : reader.GetString(addressIndex);

                        string email = reader.IsDBNull(emailIndex)
                            ? null
                            : reader.GetString(emailIndex);

                        return new PersonDTO(
                                reader.GetInt32(personIDIndex),
                                reader.GetString(firstNameIndex),
                                middleName,
                                reader.GetString(lastNameIndex),
                                reader.GetBoolean(genderIndex),
                                birthDate,
                                reader.GetString(nationalNoIndex),
                                address,
                                email,
                                reader.GetDateTime(createdAtIndex),
                                reader.GetString(createdByIndex)
                            );
                    }
                    else
                        return null;
                }
            }
        }


        public static List<PersonDTO> SearchByLastName(string lastName)
        {

            var persons = new List<PersonDTO>();

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_Person_SearchByLastName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LastName", lastName);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int personIDIndex = reader.GetOrdinal("PersonID");

                    int firstNameIndex = reader.GetOrdinal("FirstName");
                    int middleNameIndex = reader.GetOrdinal("MiddleName");
                    int lastNameIndex = reader.GetOrdinal("LastName");

                    int genderIndex = reader.GetOrdinal("Gender");

                    int birthDateIndex = reader.GetOrdinal("BirthDate");

                    int nationalNoIndex = reader.GetOrdinal("NationalNo");

                    int addressIndex = reader.GetOrdinal("Address");
                    int emailIndex = reader.GetOrdinal("Email");

                    int createdAtIndex = reader.GetOrdinal("CreatedAt");
                    int createdByIndex = reader.GetOrdinal("CreatedBy");



                    while (reader.Read())
                    {
                        string middleName = reader.IsDBNull(middleNameIndex)
                            ? null
                            : reader.GetString(middleNameIndex);

                        DateTime? birthDate = reader.IsDBNull(birthDateIndex)
                            ? (DateTime?)null
                            : reader.GetDateTime(birthDateIndex);

                        string address = reader.IsDBNull(addressIndex)
                            ? null
                            : reader.GetString(addressIndex);

                        string email = reader.IsDBNull(emailIndex)
                            ? null
                            : reader.GetString(emailIndex);


                        persons.Add(new PersonDTO(
                            reader.GetInt32(personIDIndex),
                            reader.GetString(firstNameIndex),
                            middleName,
                            reader.GetString(lastNameIndex),
                            reader.GetBoolean(genderIndex),
                            birthDate,
                            reader.GetString(nationalNoIndex),
                            address,
                            email,
                            reader.GetDateTime(createdAtIndex),
                            reader.GetString(createdByIndex)
                        ));
                    }
                }
            }

            return persons;
        }




    }
}
