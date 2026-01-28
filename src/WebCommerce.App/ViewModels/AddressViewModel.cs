using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebCommerce.App.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid ProviderId { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(200, ErrorMessage = "The {0} field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string Street { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "The {0} field must contain between {2} and {1} characters", MinimumLength = 1)]
        public string Number { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(200, ErrorMessage = "The {0} field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string Complement { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(8, ErrorMessage = "The {0} field must contain between {2} and {1} characters", MinimumLength = 8)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(200, ErrorMessage = "The {0} field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(100, ErrorMessage = "The {0} field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "The {0} field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string State { get; set; }
    }
}
