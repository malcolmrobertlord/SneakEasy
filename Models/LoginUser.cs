using System;
using System.ComponentModel.DataAnnotations;

namespace SneakEasy.Models
{
    public class LoginUser
    {
        [Required (ErrorMessage = "Email is required!")]
        public string LoginEmail {get;set;}
        
        [Required (ErrorMessage = "Password is required")] 
        [DataType(DataType.Password)]
        public string LoginPassword {get;set;}
    }
}