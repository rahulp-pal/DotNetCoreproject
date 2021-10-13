using System.Collections.Generic;

namespace ProjectName.Application.Users.Models
{
    public class UsersVm
    {
        public UserDto User { get; set; }
        public string UserName { get; set; }
        public IList<UserDto> UserList { get; set; }
    }
}
