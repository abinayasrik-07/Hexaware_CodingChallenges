using PetPals.Models;
using System;
using System.Collections.Generic;

namespace PetPals.Repository
{
    public interface IPetRepository
    {
        List<Pets> GetAllPets();
        int AddPet(Pets pet);
        int UpdatePet(Pets pet);
        int RemovePet(int petId);
    }
}
