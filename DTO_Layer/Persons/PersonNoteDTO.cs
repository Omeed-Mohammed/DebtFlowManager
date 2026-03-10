using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.Persons
{
    public class PersonNoteDTO
    {
        public int NoteID { get; set; }
        public int PersonID { get; set; }

        public string Note { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public PersonNoteDTO(int noteID, int personID, string note, string createdBy, DateTime createdAt)
        {
            NoteID = noteID;
            PersonID = personID;
            Note = note;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
        }
    }
}
