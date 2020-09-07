using PetworldApp.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petworld.Infrastructure.Static.Data
{
    class Datainitializer
    {
        private readonly IPetRepository _petRepo;

        public Datainitializer(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }
        
    }
}
