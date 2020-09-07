using PetworldApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetworldApp.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        Pet ReadyById(int id);

        List<Pet> ReadAll();

        Pet Update(Pet PetUpdate);

        Pet Delete(int id);
    }
}
