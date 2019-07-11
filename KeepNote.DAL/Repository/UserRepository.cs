using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KeepNote.DAL.Entities;

namespace KeepNote.DAL
{
  public class UserRepository
  {

    /*
      Declare variables of type SqlConnection and SqlCommand
    */

    public UserRepository(string connectionString)
    {
      /*
        1. create SqlConnection instance with connectionString passed
        2. create SqlDataAdapter instance for users table
        3. create DataSet instance
        4. populate DataSet with records fetched
      
       */
    }

    public List<User> GetAllUsers()
    {
      /*
        1. Traverse through the rows in table Users of DataSet
        2. For each row, populate the user object
        3. Populate list with user object
        4. return the list
       */
 
    }

    public int AddUser(User user)
    {

      /*
        1. create new DataRow
        2. populate the new DataRow with user values
        3. add this DataRow to the Rows of DataTable for Users 
        4. return the count of records
      */

       
    }

    public int SaveChanges()
    {
      /*
        using SqlCommandBuilder update the Users table with User Records from DataSet

       */
      
    }
  }
}
