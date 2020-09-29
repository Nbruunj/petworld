using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetshopApp.Infratructure.Data.REpositories
{
    public class PetTypeRepository: IPetTypeRepository
    {
        readonly PetAppContext _ctx;
        public PetType Create(PetType petType)
        {
            throw new NotImplementedException();
        }

        public PetType ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetType> ReadPetTypes()
        {
            throw new NotImplementedException();
        }

        public PetType Update(PetType petTypeUpdate)
        {
            throw new NotImplementedException();
        }

        public PetType Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
