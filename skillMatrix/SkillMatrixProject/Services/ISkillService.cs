


using SkillMatrixProject.DTOs;
using SkillMatrixProject.Models;

namespace SkillMatrixProject.Services
{
    public interface ISkillService
    {
        void AddSkill(string employeeId, string skillId);
        void DeleteSkill(string employeeId, string skillId);
        EmployeeDto GetEmployeeWithSkills(string employeeId);
        List<SkillDto> GetSkills(string employeeId);
        void UpdateSkillLevel(string employeeId, string skillId, string skillLevelId);


    }
}
