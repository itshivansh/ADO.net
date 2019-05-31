using KeepNote.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace KeepNote.DAL
{
  public class NoteRepository
  {
    SqlConnection connection;
    SqlCommand command;
    public NoteRepository(string connectionString)
    {
      connection = new SqlConnection(connectionString);
      command = new SqlCommand();
    }

    public List<Note> GetAllNotes()
    {
      connection.Open();
      command.CommandText = "select * from notes";
      command.Connection = connection;

      List<Note> noteList = new List<Note>();

      SqlDataReader dataReader;
      dataReader = command.ExecuteReader();

      while (dataReader.Read())
      {
        Note note = new Note();

        note.NoteId = Convert.ToInt32(dataReader["noteid"]);
        note.Title = dataReader["title"].ToString();
        note.Description = dataReader["description"].ToString();
        note.CreatedBy = Convert.ToInt32(dataReader["createdby"]);

        noteList.Add(note);

      }
      connection.Close();
      return noteList;
    }

    public int AddNote(Note note)
    {
      command.Connection = connection;
      connection.Open();
      command.CommandText = $"insert into notes(noteid,title,description,createdby) values" +
        $"({note.NoteId},'{note.Title}','{note.Description}','{note.CreatedBy}') ";

      int count = command.ExecuteNonQuery();
      connection.Close();
      return count;
    }
  }
}
