using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int VehicleID { get; set; }
        public string UserID { get; set; }

        [Required]
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string StateID { get; set; }

        [Required]
        public string Zipcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeID { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
