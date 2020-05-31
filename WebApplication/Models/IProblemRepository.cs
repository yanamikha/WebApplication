using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public interface IProblemRepository
    {
        void Create(Problem problem);
        void Delete(int id);
        Problem Get(int id);
        IEnumerable<Problem> GetAllProblems();
        IEnumerable<Problem> GetAllMyProblems(int id);
        void Update(Problem problem);
    }
}
