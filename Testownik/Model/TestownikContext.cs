using System;
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
            System.Data.Entity.Database.SetInitializer<TestownikContext>(null);
        }

        public DbSet<Database> Databases { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
