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
        SqlConnection con;
        SqlCommand command;
        DataSet dataSet;
        SqlDataAdapter sqlDataAdapter;

        public UserRepository(string connectionString)
    {
            /*
              1. create SqlConnection instance with connectionString passed
              2. create SqlDataAdapter instance for users table
              3. create DataSet instance
              4. populate DataSet with records fetched

             */
            con = new SqlConnection();
            con.ConnectionString = connectionString;
            sqlDataAdapter = new SqlDataAdapter("select * from Users", con);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Users");
        }

    public List<User> GetAllUsers()
    {
            /*
              1. Traverse through the rows in table Users of DataSet
              2. For each row, populate the user object
              3. Populate list with user object
              4. return the list
             */
            List<User> list = new List<User>();
            foreach (DataRow dataRow in dataSet.Tables["Users"].Rows)
            {
                User user = new User();
                user.UserId = Int32.Parse(dataRow[0].ToString());
                user.UserName = dataRow[1].ToString();
                user.Password = dataRow[2].ToString();
                user.Email = dataRow[3].ToString();
                list.Add(user);
            }
            return list;

        }

    public int AddUser(User user)
    {

            /*
              1. create new DataRow
              2. populate the new DataRow with user values
              3. add this DataRow to the Rows of DataTable for Users 
              4. return the count of records
            */
            DataRow dataRow = dataSet.Tables["Users"].NewRow();
            dataRow[0] = user.UserId;
            dataRow[1] = user.UserName;
            dataRow[2] = user.Password;
            dataRow[3] = user.Email;
            dataSet.Tables["Users"].Rows.Add(dataRow);
            int records = 0;
            foreach (DataRow dr in dataSet.Tables["Users"].Rows)
            {
                records++;
            }
            return records;


        }

    public int SaveChanges()
    {
            /*
              using SqlCommandBuilder update the Users table with User Records from DataSet

             */
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            sqlDataAdapter.Update(dataSet, "Users");
            int records = 1;
            return records;

        }
  }
}
