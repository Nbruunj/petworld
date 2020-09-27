using System;
using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainServices
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        Pet ReadById(int id);
        IEnumerable<Pet> ReadPets();
        Pet Update(Pet petUpdate);
        Pet Delete(int id);
    }
}
