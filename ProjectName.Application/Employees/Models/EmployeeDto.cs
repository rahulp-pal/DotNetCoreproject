using AutoMapper;
using ProjectName.Application.Common.Mappings;
using ProjectName.Application.Common.Models;
using ProjectName.Application.Designations.Models;
using ProjectName.Domain.Entities;

namespace ProjectName.Application.Employees.Models
{
    public class EmployeeDto : BaseModel, IMapFrom<Employee>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int DesignationId { get; set; }
        public DesignationDto Designation { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Designation, opt => opt.MapFrom(source => source.Designation));
        }
    }
}
