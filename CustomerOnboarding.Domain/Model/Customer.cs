using CustomerOnboarding.Domain.Helpers;
using CustomerOnboarding.Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Domain.Model
{
    public class Customer
    {
        [Key]
        [Required]
        public long CustomerId { get; set; }

        [Required]
        public long UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "First Name is required."), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required."), MaxLength(50)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email Address is required."), MaxLength(150)]
        [EmailAddress(ErrorMessage = "This is not a valid email address.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "State is required."), MaxLength(50)]
        public string StateofOrigin { get; set; }
        [MaxLength(20)]
        [Required]
        public string Gender { get; set; }

        [MaxLength(150)]
        [Required]
        public string ResidentialAddress { get; set; }
        [MaxLength(20)]
        [Phone]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public DateTime LastModified { get; set; }

        public static Customer CreateCustomer(CustomerRegistrationDTO customer)
        {
            var newCustomer = Utilities.MapTo<Customer>(customer);
            newCustomer.DateRegistered = DateTime.Now;
            newCustomer.LastModified = DateTime.Now;
            return newCustomer;
        }


    }
}
