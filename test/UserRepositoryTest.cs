using KeepNote.DAL;
using KeepNote.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace test
{
  [TestCaseOrderer("test.PriorityOrderer", "test")]
  public class UserRepositoryTest : IClassFixture<UserDbSetup>
  {
    UserDbSetup _setup;// = new DbSetup();
    public UserRepositoryTest(UserDbSetup setup)
    {
      _setup = setup;
    }

    [Fact,TestPriority(0)]
    public void TestGetAllUsers()
    {

      UserRepository userRepository = new UserRepository(@"server=.\sqlexpress;database=master;integrated security=true");

      List<User> userList = userRepository.GetAllUsers();

      Assert.Equal(2, userList.Count);
    }

    [Fact,TestPriority(1)]
    public void TestAddUserWithoutSave()
    {

      UserRepository userRepository = new UserRepository(@"server=.\sqlexpress;database=master;integrated security=true");

      User newUser = new User
      {
        UserId = 103,
        UserName = "Mukesh",
        Email = "mukesh@stackroute.in",
        Password = "mukeshg@123"
      };

      Assert.Equal(3, userRepository.AddUser(newUser));

      userRepository = new UserRepository(@"server=.\sqlexpress;database=master;integrated security=true");

      List<User> userList = userRepository.GetAllUsers();

      Assert.Equal(2, userList.Count);
    }

    [Fact,TestPriority(2)]
    public void TestAddUserWithSave()
    {

      UserRepository userRepository = new UserRepository(@"server=.\sqlexpress;database=master;integrated security=true");

      User newUser = new User
      {
        UserId = 103,
        UserName = "Mukesh",
        Email = "mukesh@stackroute.in",
        Password = "mukeshg@123"
      };

      Assert.Equal(3, userRepository.AddUser(newUser));


      int count = userRepository.SaveChanges();

      userRepository = new UserRepository(@"server=.\sqlexpress;database=master;integrated security=true");

      List<User> userList = userRepository.GetAllUsers();

      Assert.Equal(1, count);

      Assert.Equal(3, userList.Count);
    }


  }
}
