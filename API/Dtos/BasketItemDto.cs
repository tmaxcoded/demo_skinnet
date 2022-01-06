using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketItemDto
    {

        [Required]
        public int Id {get;set;}

        [Required]
        public string ProductName {get;set;}

        [Required]
        [Range(0.1,double.MaxValue, ErrorMessage = "Price must be greater than Zero")]
        public decimal Price {get;set;}
        [Required]
        [Range(1,double.MaxValue,ErrorMessage = "Quantity must bea at leaset 1")]
        public int Quanity {get;set;}
        [Required]
        public string PictureUrl {get;set;}
        [Required]
        public string Brand {get;set;}
        [Required]
        public string Type {get;set;}
    }
}