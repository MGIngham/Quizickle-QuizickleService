using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizickleService.Models;

namespace QuizickleService.Models
{
    public class QuizickleServiceContext : DbContext
    {
        public QuizickleServiceContext (DbContextOptions<QuizickleServiceContext> options)
            : base(options)
        {
        }

        public DbSet<QuizickleService.Models.Question> Questions { get; set; }

        public DbSet<QuizickleService.Models.Quiz> Quiz { get; set; }
    }
}
