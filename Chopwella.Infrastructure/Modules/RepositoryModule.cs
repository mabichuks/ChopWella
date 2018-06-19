using Chopwella.DomainInterface;
using Ninject.Modules;

namespace Chopwella.Infrastructure.Modules
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(ChopwellaRepo<>));
        }
    }
}
