using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizickleService.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        public string QuizName { get; set; }

        public List<Quiz> Quizzes { get; set; }
    }
}
