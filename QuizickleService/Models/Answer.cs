using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizickleService.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        public int QuizId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int RoundId { get; set; }

        [Required]
        public int QuestionId { get; set; }
        
        [Required]
        public int Point { get; set; }

        [Required]
        public int AnswerIndex { get; set; }

        [Required]
        public string AnswerString { get; set; }


    }
}
