using Autofac;
using Autofac.Features.Indexed;
using Microsoft.Extensions.CommandLineUtils;
using AbDevel.IdentityServer4.Cli.Commands;
using AbDevel.IdentityServer4.Cli.Enums;

namespace AbDevel.IdentityServer4.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            startup.ConfigureServices();

            var app = new CommandLineApplication();
            var list = app.Command("list", c => {
                c.OnExecute(() => {
                    c.ShowHelp();
                    return 0;
                });
                c.HelpOption("-h | --help");
            });
            list.Command("client", c => {
                c.OnExecute(() => {
                    using(var scope = startup.ApplicationContainer.BeginLifetimeScope())
                    {
                        var command = scope.Resolve<IIndex<CommandsEnum, ICommand>>();
                        return command[CommandsEnum.ListClient].Execute();
                    }
                });
            });
            list.Command("api", c => {

            });
            var add = app.Command("add", c => {
                c.OnExecute(() => {
                    c.ShowHelp();
                    return 0;
                });
                c.HelpOption("-h | --help");
            });
            add.Command("help", c => {
                c.Description = "help";
                c.OnExecute(() => {
                    c.ShowHelp("add");
                    return 0;
                });
            });
            add.Command("client", c => {
                c.Description = "Add a new client";
                c.OnExecute(() => {
                    using(var scope = startup.ApplicationContainer.BeginLifetimeScope())
                    {
                        var command = scope.Resolve<IIndex<CommandsEnum, ICommand>>();
                        return command[CommandsEnum.AddClient].Execute();
                    }
                });
            });
            add.Command("api", c => {
                c.Description = "Add a new API Resource";
                c.OnExecute(() => {
                    using(var scope = startup.ApplicationContainer.BeginLifetimeScope())
                    {
                        var command = scope.Resolve<IIndex<CommandsEnum, ICommand>>();
                        return command[CommandsEnum.AddApi].Execute();
                    }
                });
            });
            app.Command("help", c => {
                c.Description = "Help";
                c.OnExecute(() => {
                    c.ShowHelp("app");
                    return 0;
                });
            });
            app.HelpOption("-h | --help");
            app.Execute(args);
        }

        static void Setup()
        {

        }
    }
}
