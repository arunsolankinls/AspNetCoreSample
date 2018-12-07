using AspNetCoreSampleApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspNetCoreSampleApp.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
