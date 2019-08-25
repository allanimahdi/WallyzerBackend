using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TableauxApi.Models
{
    public class TableauContext : DbContext
    {
        public TableauContext(DbContextOptions<TableauContext> options) : base(options)
        {
     
        }
        public DbSet<Tableau> Tableaux { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
