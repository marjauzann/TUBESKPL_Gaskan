using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Sendit.Model
{
    class Order
    {
        public User Sender { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string SenderPhone { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientPhone { get; set; }
        public string PackageType { get; set; }
        public double PackageWeight { get; set; }
        public double Distance { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"Sender: {SenderName}, Recipient: {RecipientName}, Distance: {Distance} km, Price: {Price}, Status: {Status}";
        }
    }
}
