using PetPals.Models;
using PetPals.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetPals.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly string connectionString;
        private readonly SqlCommand cmd;
        public PetRepository() 
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }
        public List<Pets> GetAllPets()
        {
            List<Pets> pets = new List<Pets>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "SELECT * FROM Pets";
                    //cmd.Connection = SqlConnection;
                    //sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        pets.Add(new Pets(
                            reader.GetInt32(0),                  
                            reader.GetString(1),                 
                            reader.GetInt32(2),                  
                            reader.GetString(3),                 
                            reader.GetString(4),                 
                            reader.GetBoolean(5),               
                            reader.IsDBNull(6) ? 0 : reader.GetInt32(6)
                        ));
                    }
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    //return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return pets;
        }

        public int AddPet(Pets pet)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    //cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Pets (Name, Age, Breed, Type, AvailableForAdoption) VALUES (@Name, @Age, @Breed, @Type, @Available)";
                    //cmd.Parameters.AddWithValue("@PetID", pet.PetID);
                    cmd.Parameters.AddWithValue("@Name", pet.Name);
                    cmd.Parameters.AddWithValue("@Age", pet.Age);
                    cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                    cmd.Parameters.AddWithValue("@Type", pet.Type);
                    cmd.Parameters.AddWithValue("@Available", pet.AvailableForAdoption);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }

        public int UpdatePet(Pets pet)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "UPDATE Pets SET Name = @Name, Age = @Age, Breed = @Breed, Type = @Type, AvailableForAdoption = @Available WHERE PetID = @PetID";
                    cmd.Parameters.AddWithValue("@Name", pet.Name);
                    cmd.Parameters.AddWithValue("@Age", pet.Age);
                    cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                    cmd.Parameters.AddWithValue("@Type", pet.Type);
                    cmd.Parameters.AddWithValue("@Available", pet.AvailableForAdoption);
                    cmd.Parameters.AddWithValue("@PetID", pet.PetID);
                    sqlConnection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }

        public int RemovePet(int petId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "DELETE FROM Pets WHERE PetID = @PetID";
                    cmd.Parameters.AddWithValue("@PetID", petId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }
    }
}

