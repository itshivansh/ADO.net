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
    SqlConnection connection = null;
    SqlDataAdapter sda = null;

    DataSet ds;

    public UserRepository(string connectionString)
    {
      connection = new SqlConnection(connectionString);

      sda = new SqlDataAdapter("select * from users", connection);
      ds = new DataSet();
      sda.Fill(ds, "Users");
    }

    public List<User> GetAllUsers()
    {
      List<User> employeeList = new List<User>();

      foreach (DataRow dr in ds.Tables["Users"].Rows)
      {
        User user = new User();

        user.UserId = Convert.ToInt32(dr["userid"]);
        user.UserName = dr["username"].ToString();
        user.Email = dr["email"].ToString();
        user.Password = dr["password"].ToString();

        employeeList.Add(user);
      }
      return employeeList;
    }

    public int AddUser(User user)
    {
      DataRow newRow = ds.Tables["Users"].NewRow();
      newRow["userid"] = user.UserId;
      newRow["username"] = user.UserName;
      newRow["email"] = user.Email;
      newRow["password"] = user.Password;
         
      ds.Tables["Users"].Rows.Add(newRow);

      return ds.Tables["Users"].Rows.Count;
    }

    public int SaveChanges()
    {
      SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sda);
      return sda.Update(ds, "Users");
    }
  }
}
