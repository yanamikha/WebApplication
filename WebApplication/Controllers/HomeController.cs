using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("{id}", Name = "GetProblemById")]
        public Problem GetProblemById(int id)
        {
            ProblemRepository problem = new ProblemRepository(Startup.connectionString);
            return problem.Get(id);       
        }


        [Route("getallproblems")]
        [HttpGet(Name = "GetAllProblems")]
        public IEnumerable<Problem> GetAllProblems()
        {
            ProblemRepository problem = new ProblemRepository(Startup.connectionString);
            IEnumerable<Problem> problems = problem.GetAllProblems();
            return problems;
        }

        [Route("getallanswers/{problemId}")]
        [HttpGet("{problemId}", Name = "GetAllAnswers")]
        public IEnumerable<Answer> GetAllAnswers(int problemId)
        {
            AnswerRepository answer = new AnswerRepository(Startup.connectionString);
            IEnumerable<Answer> answers = answer.GetAllAnswers(problemId);
            return answers;
        }

        [Route("PostProblem/id")]
        [HttpPost("{id}", Name = "PostProblem")]
        public void PostProblem(string id)
        {
            Problem problem = new Problem { problem = id };
            ProblemRepository problemRepository = new ProblemRepository(Startup.connectionString);
            problemRepository.Create(problem);
        }

        [Route("PostAnswer/{problemId}/{value}")]
        [HttpPost("{problemId}/{value}", Name = "PostAnswer")]
        public void PostAnswer(int problemId, string value)
        {
            Answer answer = new Answer { answer = value, problem = problemId };
            AnswerRepository answerRepository = new AnswerRepository(Startup.connectionString);
            answerRepository.Create(answer);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
