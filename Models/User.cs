using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class RegistrationUser
    {
        [Required]
        public string first_name {get;set;}
        [Required]
        public string last_name {get;set;}
        [EmailAddress]
        public string email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password {get;set;}
        [DataType(DataType.Password)]
        [Required]
        [Compare("password")]
        public string confirm {get;set;}
    }
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public string email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password {get;set;}
    }
}