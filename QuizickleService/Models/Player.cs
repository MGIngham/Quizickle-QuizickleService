using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizickleService.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string PlayerName { get; set; }

    }
}
