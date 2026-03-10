using DTO_Layer.Persons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtFlowManager_DA.Persons
{
    public class PersonNoteRepository
    {
        public static int AddPersonNote(PersonNoteDTO personNote, string currentUser)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_PersonNote_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", personNote.PersonID);

                command.Parameters.AddWithValue("@Note", personNote.Note);

                command.Parameters.AddWithValue("@CurrentUser", currentUser);


                connection.Open();
                var result = command.ExecuteScalar();

                return Convert.ToInt32(result) > 0 ? 1 : 0;
            }
        }

        public static List<PersonNoteDTO> GetNoteByPersonID(int personID)
        {
            var personNotes = new List<PersonNoteDTO>();

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_PersonNote_GetByPersonID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", personID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int noteIDIndex = reader.GetOrdinal("NoteID");
                    int personIDIndex = reader.GetOrdinal("PersonID");

                    int noteIndex = reader.GetOrdinal("Note");
                    int CreatedByIndex = reader.GetOrdinal("CreatedBy");
                    int CreatedAtIndex = reader.GetOrdinal("CreatedAt");

                    while (reader.Read())
                    {

                        personNotes.Add(new  PersonNoteDTO(
                                reader.GetInt32(noteIDIndex),
                                reader.GetInt32(personIDIndex),
                                reader.GetString(noteIndex),
                                reader.GetString(CreatedByIndex),
                                reader.GetDateTime(CreatedAtIndex)
                            ));
                    }

                }
            }

            return personNotes;
        }
    }
}
