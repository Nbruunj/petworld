using PetworldApp.Core.DomainService;
using PetworldApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PetworldApp.Core.ApplicationService.impl
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;
        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Pet NewPet(String name, String type, DateTime birthdate, DateTime soldDate, string color, String previousOwner, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                Birthdate = birthdate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price

            };
            return pet;
        }
        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }


        public Pet FindeItemById(int id)
        {
            return _petRepo.ReadyById(id);
        }

       

        public List<Pet> GetPets()
        {
            return _petRepo.ReadAll().ToList();
        }
 
        public List<Pet> GetAllByPetType(string type)
        {
            var list = _petRepo.ReadAll();
            var queryContinued = list.Where(pet => pet.Type.Equals(type));
            queryContinued.OrderBy(pet => pet.Type);
            
            return queryContinued.ToList();
        }

       
        public Pet UpdatePet(Pet petupdate)
        {
            var pet = FindeItemById(petupdate.Id);
            pet.Name = petupdate.Name;
            pet.Type = petupdate.Type;
            pet.Birthdate = petupdate.Birthdate;
            pet.SoldDate = petupdate.SoldDate;
            pet.Color = petupdate.Color;
            pet.PreviousOwner = petupdate.PreviousOwner;
            pet.Price = petupdate.Price;
            return pet;

        }
        public Pet DeletePet(int id)
        {
            return _petRepo.Delete(id);
        }

        public List<Pet> GetAllPetByPrice()
        {
            var list = _petRepo.ReadAll();
            var queryContinued = list.OrderBy(pet => pet.Price);
            return queryContinued.ToList();
        }
        public List<Pet> GetFiveCheapestPets()
        {
            var list = _petRepo.ReadAll();
            var queryContinued = list.OrderBy(pet => pet.Price);
            var fiveCheapestPets = queryContinued.Take(5);
            return fiveCheapestPets.ToList();
        }

    }
}
