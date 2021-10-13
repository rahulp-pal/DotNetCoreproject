using AutoMapper;
using ProjectName.Application.Common.Mappings;
using ProjectName.Application.Common.Models;
using ProjectName.Domain.Entities;

namespace ProjectName.Application.Designations.Models
{
    public class DesignationDto: BaseModel, IMapFrom<Designation>
    {
        public string Name { get; set; }
        public string Rank { get; set; }
        public string BasicSalary { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Designation, DesignationDto>();
        }
    }
}
