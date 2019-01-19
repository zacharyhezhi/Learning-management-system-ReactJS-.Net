using Autofac;
using Data.Database;
using Data.Repositories;
using Data.Repositories.Interfaces;
using System.Reflection;

namespace Data
{
    public class RepositoryCompositionRoot
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(currentAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterType<LMSEntities>().AsSelf().InstancePerRequest();
            //builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();

        }
    }
}
