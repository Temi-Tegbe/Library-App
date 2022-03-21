using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarding.Domain.Model.DTO
{
    public class CustomerRegistrationDTO : CustomerBase
    {
        [Required(ErrorMessage = "Password is required."), MinLength(8), MaxLength(20)]
        public string Password { get; set; }
    }
}
