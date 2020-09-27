using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetshopApp.Infratructure.Data.REpositories
{
    public class PetRepository: IPetRepository
    {
        readonly PetAppContext _ctx;

        public PetRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }

        public Pet Create(Pet pet)
        {
            var pett = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return pett;
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet Update(Pet petUpdate)
        {
            throw new NotImplementedException();
        }

        public Pet Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
