using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ZookeeperApp.Models
{
    public class ZooDBContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalFood> AnimalFoods { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}