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

    public NoteRepository(string connectionString)
    {
      /*
        Instantiate SqlConnection object with the connectionString passed to the constructor
        Instantiate SqlCommand object
       */
      
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
    
      return null;
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

      
    }
  }
}
