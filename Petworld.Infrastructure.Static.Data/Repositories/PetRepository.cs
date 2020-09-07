using PetworldApp.Core.DomainService;
using PetworldApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petworld.Infrastructure.Static.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;

        private List<Pet> _pets = new List<Pet>();
        public Pet Create(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

       

        public List<Pet> ReadAll()
        {
            return _pets;
        }

        public Pet ReadyById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Update(Pet PetUpdate)
        {
            var petfromDb = this.ReadyById(PetUpdate.Id);
            if (petfromDb != null)
            {
                petfromDb.Name = PetUpdate.Name;

                petfromDb.Type = PetUpdate.Type;

                petfromDb.Birthdate = PetUpdate.Birthdate;

                petfromDb.SoldDate = PetUpdate.SoldDate;
                petfromDb.Color = PetUpdate.Color;
                petfromDb.PreviousOwner = PetUpdate.PreviousOwner;
                petfromDb.Price = PetUpdate.Price;

                return petfromDb;
            }
            return null;
        } public Pet Delete(int id)
        {
            var petfound = this.ReadyById(id);

            if (petfound != null)
            {
                _pets.Remove(petfound);
                return petfound;
            }
            return null;
        }
    }
}
