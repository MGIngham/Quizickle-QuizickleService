using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizickleService.Models
{
    public class Round
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        [Required]
        public int RoundNumber { get; set; }
        public string RoundName { get; set; }
    }
}
