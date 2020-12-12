using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using ReVision.Model;

namespace ReVision
{
    class RevisionContext : DbContext
    {


        public DbSet<Subject> Subjects { get; set; }
        public DbSet<QAModel> QuestionAnswer { get; set; }
        public DbSet<Proposition> Proposition { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {

            
            optionsBuilder.UseSqlite("Data Source=./Revision.db");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
