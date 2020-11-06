using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizickleService.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        [Required]
        public int RoundNumber { get; set; }
        [Required]
        public int QuestionType { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public bool IsTrueFalse { get; set; }
        public string AnswerText { get; set; }
        public string OptionOne { get; set; }
        public string OptionTwo { get; set; }
        public string OptionThree { get; set; }


    }
}
