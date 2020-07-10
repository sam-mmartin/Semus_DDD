using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
    }
}
