using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
    public interface ITeacherRepository
    {
         Task<Teacher> GetTeacher();
         Task<Teacher> GetAllTeachers();
         Task<Teacher> CreateTeacher();
         Task<Teacher> UpdateTeacher();
         Task<Teacher> DeleteTeacher();
    }
}