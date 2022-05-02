using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SneakEasy.Models
{
    public class Sneaker
    {
        [Key]
        public int SneakerId {get;set;}

        [Required (ErrorMessage = "You must provide a name")]
        public string Name {get;set;}

        [Required (ErrorMessage = "You must provide a photo of the shoes")]
        public string PhotoURL {get;set;}

        public byte[] ImageData { get; set; }

        [Required (ErrorMessage = "You must provide a price")]
        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        public double? Price {get;set;}

        [Required (ErrorMessage = "You must provide a size")]
        [Range(1, 20, ErrorMessage = "Your shoe size must be between 1 and 20")]
        public int? Size {get;set;}

        [Required]
        public string Brand {get;set;}

        //one to many connection
        public int UserId {get;set;}
        public User Seller {get;set;}

        //many to many
        public List<Order> CustomerOrders {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}