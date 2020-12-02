using KeepNote.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace KeepNote.DAL
{
  public class NoteRepository
  {
        /*
          Declare variables of type SqlConnection and SqlCommand
        */
        SqlConnection con ;
        SqlCommand command ;

    public NoteRepository(string connectionString)
            
    {
            /*
              Instantiate SqlConnection object with the connectionString passed to the constructor
              Instantiate SqlCommand object
             */
            con = new SqlConnection();
            command = new SqlCommand();
            con.ConnectionString = connectionString;


        }

    //Read all notes 
    public List<Note> GetAllNotes()
    {
            /*
              1. open connection
              2. set the command text of SqlCommand object with appropriate query to read all notes
              3. using ExecuteReader() method of SqlCommand object fetch data
              4. Recursively read the records fetced one by one and populate the note object
              5. Populate the list object with note object on each iteration
              6. close the connection
              7. Return the populated list
            */

            List<Note> list = new List<Note>();
            con.Open();
            command.CommandText = "select * from Notes";
            command.Connection = con;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Note note = new Note();
                note.NoteId = sqlDataReader.GetInt32(0);
                note.Title = sqlDataReader.GetString(1);
                note.Description = sqlDataReader.GetString(2);
                note.CreatedBy = sqlDataReader.GetInt32(3);
                list.Add(note);
            }
            con.Close();
            return list;
        }

    public int AddNote(Note note)
    {

            /*
              1. open connection
              2. set the command text of SqlCommand object with appropriate query to insert note record
              3. execute ExecuteNonQuery() method 
              4. close the connection
              5. return the count of records
            */
            con.Open();
            command.CommandText = "insert into Notes values (@NoteId, @Title, @Description, @CreatedBy)";
            command.Parameters.AddWithValue("@NoteId", note.NoteId);
            command.Parameters.AddWithValue("@Title", note.Title);
            command.Parameters.AddWithValue("@Description", note.Description);
            command.Parameters.AddWithValue("@CreatedBy", note.CreatedBy);
            command.Connection = con;
            command.ExecuteNonQuery();

            command.CommandText = "select * from notes";
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int records = 1;
            con.Close();
            return records;


        }
  }
}
