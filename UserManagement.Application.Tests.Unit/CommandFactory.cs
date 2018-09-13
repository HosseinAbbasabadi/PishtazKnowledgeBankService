using System.Collections.Generic;
using UserManagement.Interface.Facade.Contract;

namespace UserManagement.Application.Tests.Unit
{
    public class Commands
    {
        public CreateUser CreateUser { get; set; }
    }

    public static class CommandFactory
    {
        public static Commands BuildACommandOfType()
        {
            return new Commands
            {
                CreateUser = new CreateUser
                {
                    Username = "sharkProgrammer",
                    Password = "123456",
                    Firstname = "hossein",
                    Lastname = "abbasabadi",
                    Roles = new List<long> {1}
                }
            };
        }
    }
}