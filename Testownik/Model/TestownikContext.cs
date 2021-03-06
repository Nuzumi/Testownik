﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testownik.Model
{
    public class TestownikContext : DbContext
    {
        public TestownikContext()
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<TestownikContext>(null);
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ArchQuestion> ArchQuestions { get; set; }
        public DbSet<ArchStat> ArchStats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}
