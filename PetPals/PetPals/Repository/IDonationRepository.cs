using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Repository
{
    public interface IDonationRepository
    {
        void RecordCashDonation(string donorName, decimal amount, DateTime donationDate, int shelterId);
        void RecordItemDonation(string donorName, string itemType, int shelterId);

    }
}
