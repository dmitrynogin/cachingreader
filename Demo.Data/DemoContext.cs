using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class DemoContext : DbContext
    {
        public DbSet<CarMake> CarMakes { get; set; }
    }

    public class CarMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
