using System;
using System.ComponentModel.DataAnnotations;

namespace SneakEasy.Models
{
    public class Order
    {
        [Key]
        public int OrderId {get;set;}
        public int UserId {get;set;}
        //nav property
        public User Buyer {get;set;}
        public int SneakerId {get;set;}
        public Sneaker Sneaker {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
    }
}