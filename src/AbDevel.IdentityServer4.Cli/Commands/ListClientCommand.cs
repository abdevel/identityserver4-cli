using System;
using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AbDevel.IdentityServer4.Cli.Commands
{
    public class ListClientCommand : ICommand
    {
        readonly ConfigurationDbContext _context;
        public ListClientCommand(ConfigurationDbContext context)
        {
            _context = context;
        }

        public int Execute()
        {
            var clients = _context.Clients.Include(c => c.AllowedScopes).AsQueryable();
            foreach(var client in clients)
            {
                Console.WriteLine($"Id: {client.ClientId}");
                Console.WriteLine($"Scopes: {string.Join(",", client.AllowedScopes.Select(s => s.Scope))}");
            }
            return 0;
        }
    }
}
