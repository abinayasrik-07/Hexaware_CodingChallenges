using PetPals.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Repository
{
    public class DonationRepository : IDonationRepository
    {
        private readonly string connectionString;
        private SqlCommand cmd;

        public DonationRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public void RecordCashDonation(string donorName, decimal amount, DateTime donationDate, int shelterId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "INSERT INTO Donations (DonorName, DonationType, DonationAmount, DonationDate, ShelterID) VALUES (@DonorName, 'Cash', @Amount, @Date, @ShelterID)";
                    cmd.Parameters.AddWithValue("@DonorName", donorName);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Date", donationDate);
                    cmd.Parameters.AddWithValue("@ShelterID", shelterId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RecordItemDonation(string donorName, string itemType, int shelterId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "INSERT INTO Donations (DonorName, DonationType, DonationItem, ShelterID) VALUES (@DonorName, 'Item', @Item, @ShelterID)";
                    cmd.Parameters.AddWithValue("@DonorName", donorName);
                    cmd.Parameters.AddWithValue("@Item", itemType);
                    cmd.Parameters.AddWithValue("@ShelterID", shelterId);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
