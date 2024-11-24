using PetPals.Models;
using PetPals.Repository;
using PetPals.Service;
using PetPals.Services;
using System;
using System.Collections.Generic;

namespace PetPals.Services
{
    internal class PetService : IPetService
    {
        private readonly PetRepository petRepo;

        public PetService()
        {
            petRepo = new PetRepository();
        }

        // Method to retrieve all available pets
        public void GetAvailablePets()
        {
            List<Pets> pets = petRepo.GetAllPets();

            if (pets.Count == 0)
            {
                Console.WriteLine("No pets available for adoption.");
            }
            else
            {
                Console.WriteLine("\nAvailable Pets for Adoption:");
                foreach (var pet in pets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
        }

        // Method to insert a new pet
        public void InsertPet(Pets pet)
        {
            //try
            //{
            //    petRepo.AddPet(pet);
            //    Console.WriteLine($"Pet '{pet.Name}' has been successfully added to the shelter!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error adding pet: {ex.Message}");
            //}
        }

        public void RemovePet(int petId)
        {
            throw new NotImplementedException();
        }

        // Method to remove a pet
        //public void RemovePet(int petId)
        //{
        //    try
        //    {
        //        bool isRemoved = petRepo.RemovePet(petId);
        //        if (isRemoved)
        //        {
        //            Console.WriteLine($"Pet with ID {petId} has been successfully removed.");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Pet with ID {petId} could not be found or removed.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error removing pet: {ex.Message}");
        //    }
        //}
    }
}

