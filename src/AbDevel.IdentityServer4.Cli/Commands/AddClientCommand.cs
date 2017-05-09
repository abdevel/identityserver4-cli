using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;

namespace AbDevel.IdentityServer4.Cli.Commands
{
    public class AddClientCommand : ICommand
    {
        readonly ConfigurationDbContext _context;
        public AddClientCommand(ConfigurationDbContext context)
        {
            _context = context;
        }
        public int Execute()
        {
            var client = new Client();
            Console.Write("Id: ");
            client.ClientId = Console.ReadLine();

            Console.Write("Secret: ");
            var secret = Console.ReadLine();
            var secrets = new List<Secret>();
            secrets.Add(new Secret(secret.Sha256()));
            client.ClientSecrets = secrets;

            Console.Write("Scopes (comma delimeted): ");
            var scopesRawString = Console.ReadLine();
            var scopesStrings = scopesRawString.Split(',');
            client.AllowedScopes = scopesStrings;
            _context.Clients.Add(client.ToEntity());
            _context.SaveChanges();
            return 0;
        }
    }
}
