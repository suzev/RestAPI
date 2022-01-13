using EnrollmentService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnrollmentService.Data
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByTitle(string title);

        //Task<IEnumerable<Course>> GetAllCourseAndStudent(int courseId);
    }
}
