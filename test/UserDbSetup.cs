using System;
using System.Collections.Generic;
using System.Text;
using KeepNote.DAL;
using System.Data.SqlClient;

namespace test
{
    public class UserDbSetup : IDisposable
    {
        SqlConnection con;
        SqlCommand cmd;
        public UserDbSetup()
        {
            string constr = Environment.GetEnvironmentVariable("MSSQL_URL");
            if (constr == null)
            {
                constr = @"server=.\sqlexpress;database=keepnote_db;integrated security=true";
                //constr = "server= BHISHM;database=master;user = sa;password=pass@123";
            }
            con = new SqlConnection(constr);

            cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = "create table users (userid int, username varchar(20), password varchar(15), email varchar(30))";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "insert into users values(101,'nandita','nandita@123','nandita@stackroute.in'),(102,'vikram','vikram@123','vikram@stackroute.in')";
            cmd.ExecuteNonQuery();



            con.Close();

        }

        public void Dispose()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();



            cmd.CommandText = "drop table users";
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            con.Close();
            con.Dispose();
        }
    }
}
