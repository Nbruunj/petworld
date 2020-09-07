using Microsoft.Extensions.DependencyInjection;
using Petworld.Infrastructure.Static.Data.Repositories;
using PetworldApp.Core.ApplicationService;
using PetworldApp.Core.ApplicationService.impl;
using PetworldApp.Core.DomainService;
using System;

namespace petworld
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
    }
}
