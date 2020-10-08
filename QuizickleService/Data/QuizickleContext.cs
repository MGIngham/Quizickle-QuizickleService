using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizickleService.Models;

namespace QuizickleService.Data
{
    public class QuizickleContext : DbContext
    {
        public QuizickleContext (DbContextOptions<QuizickleContext> options)
            : base(options)
        {
        }

        public DbSet<QuizickleService.Models.Quiz> Quiz { get; set; }

        public DbSet<QuizickleService.Models.Question> Question { get; set; }

        public DbSet<QuizickleService.Models.Round> Round { get; set; }
    }
}
