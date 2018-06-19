using System.Data.Entity;

namespace Chopwella.Infrastructure
{
    class ChopwellaDBContext : DbContext
    {
        public ChopwellaDBContext() : base("ChopWellaDB")
        {

        }
    }
}
