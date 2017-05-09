using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AbDevel.IdentityServer4.Cli.Commands;
using AbDevel.IdentityServer4.Cli.Enums;

namespace AbDevel.IdentityServer4.Cli
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IContainer ApplicationContainer { get; private set; }
        public IConfigurationRoot Configuration { get; private set; }
        public void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddIdentityServer()
                .AddConfigurationStore(b =>
                    b.UseMySql(Configuration["IS4_CONNECTION_STRING"]))
                .AddOperationalStore(b =>
                    b.UseMySql(Configuration["IS4_CONNECTION_STRING"]));

            var builder = new ContainerBuilder();
            builder.RegisterType<AddApiResourceCommand>()
                .Keyed<ICommand>(CommandsEnum.AddApi);
            builder.RegisterType<AddClientCommand>()
                .Keyed<ICommand>(CommandsEnum.AddClient);
            builder.RegisterType<ListClientCommand>()
                .Keyed<ICommand>(CommandsEnum.ListClient);
            builder.Populate(services);
            ApplicationContainer = builder.Build();
        }

    }
}
