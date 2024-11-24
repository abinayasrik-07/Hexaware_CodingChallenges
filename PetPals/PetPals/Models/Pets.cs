
using System;
using Azure;
using PetPals.Models;
using PetPals.Repository;

namespace PetPals.Models
{
    public class Pets
    {
        public int PetID { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; } 
        public string Breed { get; set; } 
        public string Type { get; set; } 
        public bool AvailableForAdoption { get; set; } 
        public int ShelterID { get; set; } 

        public Shelters Shelter { get; set; }    

        public Pets(int petID, string name, int age, string breed, string type, bool availableForAdoption, int shelterID)
        {
            PetID = petID;
            Name = name;
            Age = age;
            Breed = breed;
            Type = type;
            AvailableForAdoption = availableForAdoption;
            ShelterID = shelterID;
        }

        public override string ToString()
        {
            return $"Pet ID: {PetID}, Name: {Name}, Age: {Age}, Breed: {Breed}, Type: {Type}, Available: {AvailableForAdoption}, Shelter ID: {ShelterID}";
        }
    }
}
