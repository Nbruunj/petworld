using System;
using System.Collections.Generic;
using System.Text;
using PetworldApp.Core.Entity;

namespace PetworldApp.Core.ApplicationService
{
    public interface IPetService
    {
        Pet NewPet(String Name, String Type, DateTime Birthdate, DateTime SoldDate, string Color, String PreviousOwner, double Price);
        Pet CreatePet(Pet pet);
        Pet FindeItemById(int id);
        List<Pet> GetPets();
        List<Pet> GetAllByPetType(string type);
        
        Pet UpdatePet(Pet petupdate);
        Pet DeletePet(int id);

        List<Pet> GetAllPetByPrice();
        List<Pet> GetFiveCheapestPets();

    }
}
