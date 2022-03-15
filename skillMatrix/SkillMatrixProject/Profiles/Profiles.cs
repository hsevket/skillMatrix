using AutoMapper;
using SkillMatrixProject.DTOs;
using SkillMatrixProject.Models;

namespace SkillMatrixProject.Profiles
{
    public class Profiles: Profile
    {
        public Profiles()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee_Skill, Employee_SkillDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<ContractStatus, ContractStatusDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<EmploymentStatus, EmploymentStatusDto>().ReverseMap();
            CreateMap<Jobtitle, JobtitleDto>().ReverseMap();
            CreateMap<SkillCategory, SkillCategoryDto>().ReverseMap();
        }
    }
}
