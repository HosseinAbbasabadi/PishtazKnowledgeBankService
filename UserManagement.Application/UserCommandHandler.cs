using Framework.Application.Command;
using UserManagement.Domain;
using UserManagement.Domain.Models.Users;
using UserManagement.Interface.Facade.Contract;

namespace UserManagement.Application
{
    public class UserCommandHandler : ICommandHandler<CreateUser>
    {
        private const string UserSequence = "UserSeq";
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(CreateUser command)
        {
            var id = _userRepository.GetNextId(UserSequence);
            var userId = new UserId(id);
            var user = new User(userId, command.Username, command.Password, command.Firstname, command.Lastname,
                command.Roles);
            _userRepository.Create(user);
        }
    }
}