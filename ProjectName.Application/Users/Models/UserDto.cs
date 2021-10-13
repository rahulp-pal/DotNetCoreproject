using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectName.Application.Common.Mappings;

namespace ProjectName.Application.Users.Models
{
    public class UserDto : IMapFrom<IdentityUser>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityUser, UserDto>();
        }
    }
}
