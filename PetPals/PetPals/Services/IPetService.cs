using PetPals.Models;
using System.Collections.Generic;

namespace PetPals.Service
{
    internal interface IPetService
    {
        void GetAvailablePets(); // Method to retrieve all available pets
        void InsertPet(Pets pet); // Method to insert a new pet
        void RemovePet(int petId); // Method to remove a pet by ID
    }
}

