
using AutoMapper;
using skillMatrix.WebAPI.Data.DataContext;
using SkillMatrixProject.DTOs;
using SkillMatrixProject.Models;
using SkillMatrixProject.Repositories;

namespace SkillMatrixProject.Services
{
    public class SkillService : ISkillService
    {
       private readonly SkillMatrixDbContext db;
        private readonly IMapper mapper;
        public SkillService(SkillMatrixDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void AddSkill(string employeeId, string skillId)
        {
          var employee =  db.Employees.Find(employeeId);
            if (employee == null)
                throw new Exception("employee has not been found");
           var skill =  db.Skills.Find(skillId);
            if (skill == null)
                throw new Exception("skill has not been found");
            var newEmployeeSkill = new Employee_Skill(employeeId, skillId);
            db.Employee_Skills.Add(newEmployeeSkill);
            db.SaveChanges();
            
        }

        public List<SkillDto> GetSkills(string employeeId)
        {
            var employee = db.Employees.Find(employeeId);
            if (employee == null)
                throw new Exception("error");
            var skills = db.Employee_Skills.Where(x => x.EmployeeId == employeeId).ToList();
            var result = new List<SkillDto>();
            foreach (var skill in skills)
            {
                result.Add(mapper.Map<SkillDto>(skill));
            }   
            return result;
        }
        public EmployeeDto GetEmployeeWithSkills(string employeeId)
        {
            var employee = db.Employees.Find(employeeId);
            if (employee == null)
                throw new Exception("error");
            var skills = db.Employee_Skills.Where(x => x.EmployeeId == employeeId).ToList();
            var employeeDto = mapper.Map<EmployeeDto>(employee);
            foreach (var empskill in skills)
            {
                var skill = db.Skills.Find(empskill.SkillId);
                var skillDto = mapper.Map<SkillDto>(skill);
                employeeDto.Skills.Add(skillDto);
                skillDto.SkillLevel = db.SkillLevels.Find(empskill.SkillLevelId);
            }
            return employeeDto;
        }

        public void DeleteSkill(string employeeId, string skillId)
        {
  
            var deletedSkill = db.Employee_Skills.Where(x => x.EmployeeId == employeeId && x.SkillId == skillId).FirstOrDefault();
            if (deletedSkill == null)
            {
                throw new Exception("skill has not been found");
            }
            db.Employee_Skills.Remove(deletedSkill);
            db.SaveChanges();
        }

        public void UpdateSkillLevel(string employeeId, string skillId, string skillLevelId)
        {
            var employee = db.Employees.Find(employeeId);
            if (employee == null)
                throw new Exception("employee has not been found");
           
            var skillLevel = db.SkillLevels.Find(skillLevelId);
            if (skillLevel == null)
                throw new Exception("skill level has not been found");
           var skill = db.Employee_Skills.Where(x => x.SkillId == skillId && x.EmployeeId == employeeId).FirstOrDefault();
            if(skill == null)
                throw new Exception("skill has not been found");
            skill.SkillLevelId = skillLevelId;
            db.SaveChanges();
        }

       
    }
}
