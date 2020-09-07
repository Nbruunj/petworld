using Petworld.Infrastructure.Static.Data.Repositories;
using PetworldApp.Core.ApplicationService;
using PetworldApp.Core.ApplicationService.impl;
using PetworldApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace petworld
{
    class Printer : IPrinter
    {
        readonly IPetService _petService;
        public Printer(IPetService petservice)
        {
            _petService = petservice;
            InitData();
        }

       

        public void StartUI()
        {
            string[] menuPets =
            {
                "Pets Availabe",
                "Add pet",
                "Edit Pet",
                "Delete Pet",
                "search",
                "sortet By Price",
                "fiveCheapestPets",
                "Exit"
            };
            var selection = ShowMenu(menuPets);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        var pet = _petService.GetPets();
                        ListPets(pet);
                        break;

                    case 2:
                        var name = AskQuestion("Name: ");
                        var type = AskQuestion("Type: ");
                        var birthdate = AskQuestion("Birthdate: ");
                        var soldDate = AskQuestion("SoldDate: ");
                        var color = AskQuestion("Color: ");
                        var previousOwner = AskQuestion("PreviousOwner: ");
                        var price = AskQuestion("Price: ");

                        var pick = _petService.NewPet(name, type, DateTime.Parse(birthdate), DateTime.Parse(soldDate), color, previousOwner, double.Parse(price));
                        _petService.CreatePet(pick);
                        break;

                    case 3:

                        var idForEfit = PrintFindPetById();
                        var itemToEdit = _petService.FindeItemById(idForEfit);
                        Console.WriteLine("Updating " + itemToEdit.Name + " " + itemToEdit.SoldDate + " " + itemToEdit.Price);
                        var newName = AskQuestion("Name: ");
                        var newSoldDate= AskQuestion("SoldDate: ");
                        var newPrice = AskQuestion("Price: ");
                        
                        _petService.UpdatePet(new Pet()
                        {
                            Id = idForEfit,
                            Name = newName,
                            SoldDate = DateTime.Parse(newSoldDate),
                            Price = double.Parse(newPrice)

                        });

                        break;

                    case 4:
                        var idForDelete = PrintFindPetById();
                        _petService.DeletePet(idForDelete);


                        break;
                    case 5:
                        var TypeSearch = AskQuestion("Isert type of pet");
                        var PetSearch = _petService.GetAllByPetType(TypeSearch);
                        ListPets(PetSearch);
                        break;

                    case 6:

                        var sortetByPrice = _petService.GetAllPetByPrice();
                        ListPets(sortetByPrice);
                        break;
                    case 7:
                        
                        var fiveCheapestPets = _petService.GetFiveCheapestPets();
                        ListPets(fiveCheapestPets);
                        
                        break;
                    default:
                        break;

                }

                selection = ShowMenu(menuPets);
            }
            Console.WriteLine("bye bye bitch !");

            Console.ReadLine();

        }

        




        int PrintFindPetById()
        {
            Console.WriteLine("Insert Pet Id: ");

            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }


        String AskQuestion(String question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of pets");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} Name: {pet.Name} " + $"Type: {pet.Type} " + $"Birthdata: {pet.Birthdate}" +  $"SoldDate: {pet.SoldDate} " + $"Color: {pet.Color}" + $"PreviousOwner: {pet.PreviousOwner}" + $"Price: {pet.Price}");

            }
            Console.WriteLine("\n");

        }
        int ShowMenu(string[] menuPets)
        {

            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuPets.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuPets[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Please select a number between 1-8");
            }

            return selection;

        }

        private void InitData()
        {
            var pet1 = new Pet()
            {
                Name = "Mads",
                Type = "english bulldog",
                Birthdate = new DateTime(2020,04,02),
                SoldDate = new DateTime(2020, 04, 03),
                Color = "brown",
                PreviousOwner = "Mygind",
                Price = 500
            };
            _petService.CreatePet(pet1);

            var pet2 = new Pet()
            {
                Name = "Kasper",
                Type = "mops",
                Birthdate = new DateTime(2020, 01, 02),
                SoldDate = new DateTime(2020, 01, 03),
                Color = "brown",
                PreviousOwner = "Fimfi",
                Price = 400
            };
            _petService.CreatePet(pet2);
            var pet3 = new Pet()
            {
                Name = "Jonas",
                Type = "Chihuahua",
                Birthdate = new DateTime(2020, 02, 02),
                SoldDate = new DateTime(2020, 02, 03),
                Color = "red",
                PreviousOwner = "Yikes",
                Price = 200
            };
            _petService.CreatePet(pet3);
            var pet4 = new Pet()
            {
                Name = "Christian",
                Type = "Boxer",
                Birthdate = new DateTime(2020, 03, 02),
                SoldDate = new DateTime(2020, 03, 03),
                Color = "black",
                PreviousOwner = "Dreamy",
                Price = 800
            };
            _petService.CreatePet(pet4);
            var pet5 = new Pet()
            {
                Name = "Niklas",
                Type = "Rottweiler",
                Birthdate = new DateTime(2020, 05, 02),
                SoldDate = new DateTime(2020, 05, 03),
                Color = "Black",
                PreviousOwner = "The Joker",
                Price = 550
            };
            _petService.CreatePet(pet5);
            var pet6 = new Pet()
            {
                Name = "kk",
                Type = "Rottweiler",
                Birthdate = new DateTime(2020, 05, 02),
                SoldDate = new DateTime(2020, 05, 03),
                Color = "Black",
                PreviousOwner = "The Joker",
                Price = 1120
            };
            _petService.CreatePet(pet6);
        }
    }
}
