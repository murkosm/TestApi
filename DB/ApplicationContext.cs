using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Classes;

namespace TestApi.DB
{
    internal class ApplicationContext: DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = test.db");
        }
        public DbSet<Token> Tokens { get; set; }
    }
}
