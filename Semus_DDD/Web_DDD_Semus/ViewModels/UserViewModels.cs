using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_DDD_Semus.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required, Display(Name = "Nome Completo")]
        public string Name { get; set; }

        [Required, Display(Name = "Endereço")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Data de Nascimento")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Password)]
        [Required, Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required, Display(Name = "Confirme a Senha")]
        public string ConfirmPassword { get; set; }
    }
}
