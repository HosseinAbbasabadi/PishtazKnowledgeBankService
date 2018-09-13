using System;
using System.Collections.Generic;
using Framework.Application.Command;

namespace UserManagement.Interface.Facade.Contract
{
    public class CreateUser : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<long> Roles { get; set; }
    }
}