using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizickleService.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int QuizId { get; set; }

        [Required]
        public int PlayerScore { get; set; }
    }
}
