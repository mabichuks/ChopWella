using Chopwella.Core;
using System.Data.Entity;

namespace Chopwella.Infrastructure
{
    class ChopwellaDBContext : DbContext
    {
        public ChopwellaDBContext() : base("ChopWellaDB")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<CheckIn> checkIns { get; set; }
    }
}
