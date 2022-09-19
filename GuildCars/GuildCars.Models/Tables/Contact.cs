using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required]
        public string ContactName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
