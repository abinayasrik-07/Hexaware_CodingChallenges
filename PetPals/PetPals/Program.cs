
using PetPals.Models;
using PetPals.Repository;
using PetPals.Services;
using PetPals.Utility;
using System;

namespace PetPals
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IPetRepository petRepo = new PetRepository();
            IDonationRepository donationRepo = new DonationRepository();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n1. List Available Pets");
                Console.WriteLine("2. Add Pet");
                Console.WriteLine("3. Remove Pet");
                Console.WriteLine("4. Record Cash Donation");
                Console.WriteLine("5. Record Item Donation");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var pets = petRepo.GetAllPets();
                        foreach (var petss in pets)
                        {
                            Console.WriteLine(petss);
                        }
                        break;

                    case "2":
                        Console.Write("Enter Pet Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter Breed: ");
                        string breed = Console.ReadLine();
                        Console.Write("Enter Type (Dog/Cat): ");
                        string type = Console.ReadLine();

                        int petID = 0;
                        bool availableForAdoption = true;
                        int shelterID = 1;

                        var pet = new Pets(petID, name, age, breed, type, availableForAdoption, shelterID);
                        petRepo.AddPet(pet);
                        Console.WriteLine("Pet added successfully!");
                        break;

                    case "3":
                        Console.Write("Enter Pet ID to Remove: ");
                        int petId = int.Parse(Console.ReadLine());
                        petRepo.RemovePet(petId);
                        Console.WriteLine("Pet removed successfully!");
                        break;

                    case "4":
                        Console.Write("Enter Donor Name: ");
                        string donorName = Console.ReadLine();
                        Console.Write("Enter Amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Donation Date (YYYY-MM-DD): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter Shelter ID: ");
                        int shelterId = int.Parse(Console.ReadLine());

                        donationRepo.RecordCashDonation(donorName, amount, date, shelterId);
                        Console.WriteLine("Cash donation recorded successfully!");
                        break;

                    case "5":
                        Console.Write("Enter Donor Name: ");
                        donorName = Console.ReadLine();
                        Console.Write("Enter Item Type: ");
                        string itemType = Console.ReadLine();
                        Console.Write("Enter Shelter ID: ");
                        shelterId = int.Parse(Console.ReadLine());

                        donationRepo.RecordItemDonation(donorName, itemType, shelterId);
                        Console.WriteLine("Item donation recorded successfully!");
                        break;

                    case "6":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

