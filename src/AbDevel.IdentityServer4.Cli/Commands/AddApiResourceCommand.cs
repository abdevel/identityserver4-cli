using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;

namespace AbDevel.IdentityServer4.Cli.Commands
{
    public class AddApiResourceCommand : ICommand
    {
        readonly ConfigurationDbContext _context;
        public AddApiResourceCommand(ConfigurationDbContext context)
        {
            _context = context;
        }
        public int Execute()
        {
            var apiResource = new ApiResource();
            Console.Write("Name: ");
            apiResource.Name = Console.ReadLine();
            Console.Write("Display Name: ");
            apiResource.DisplayName = Console.ReadLine();
            Console.Write("Description: ");
            apiResource.Description = Console.ReadLine();
            Console.Write("Scopes (comma delimeted): ");
            var scopesRawString = Console.ReadLine();
            var scopesStrings = scopesRawString.Split(',');
            apiResource.Scopes = new List<Scope>(scopesStrings.Select(s => new Scope(s)));
            _context.ApiResources.Add(apiResource.ToEntity());
            _context.SaveChanges();
            return 0;
        }
    }
}
