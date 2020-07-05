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
        public int QuestionId { get; set; }

        [Required]
        public int QuestionNumber { get; set; }

        [Required]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        [Required]
        public int RoundNumber { get; set; }

        [Required]
        public string QuestionString { get; set; }

        [Required]
        public int QuestionTypeId { get; set; }

        [Required]
        public int CorrectAnswerIndex { get; set; }

        public string AnswerString { get; set; }

        public string OptionOne { get; set; }

        public string OptionTwo { get; set; }

        public string OptionThree { get; set; }

        public string OptionFour { get; set; }


    }
}
