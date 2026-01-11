using AutoMapper;
using AutoMapper.Configuration.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebCommerce.App.Extensions;
using WebCommerce.Business.Models;

namespace WebCommerce.App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [DisplayName("Provider")]
        public Guid ProviderId { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(200, ErrorMessage = "The {0} field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(1000, ErrorMessage = "The {0} field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        public string Image { get; set; }

        [DisplayName("Product Image")]
        public IFormFile ImageUpload { get; set; }

        [Currency]
        [Required(ErrorMessage = "The {0} field is required")]
        public decimal Value { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }

        public ProviderViewModel Provider { get; set; }

        public IEnumerable<ProviderViewModel> Providers { get; set; }
    }
}
