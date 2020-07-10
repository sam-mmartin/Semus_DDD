using Entities.Entity.Client;
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
        public int OfficeID { get; set; }
        public int DepartmentID { get; set; }

        public virtual Office Office { get; set; }
        public virtual Department Department { get; set; }
    }
}
