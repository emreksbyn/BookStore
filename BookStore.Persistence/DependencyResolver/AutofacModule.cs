using Autofac;
using BookStore.Application.UnitOfWork;
using BookStore.Persistence.UnitOfWorkConcrete;

namespace BookStore.Persistence.DependencyResolver
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}