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
        public int Id { get; set; }
        [Required]
        public string QuizName { get; set; }
        public string BackgroundColour { get; set; }

        public List<Question> Questions { get; set; }
        public List<Round> Rounds { get; set; } 
    }
}
