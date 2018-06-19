using Chopwella.DomainInterface;
using Chopwella.ServiceInterface;
using Chopwella.Services;
using Ninject.Modules;

namespace Chopwella.Infrastructure.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IServices<>)).To(typeof(ChopWellaService<>)).WithConstructorArgument(typeof(IRepository<>));
        }
    }
}
