using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Answer
    {
        public int id { get; set; }
        public int problem { get; set; }
        public string answer { get; set; }
    }
}
