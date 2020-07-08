using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web_DDD_Semus.ViewModels
{
    public class CreateStockViewModel
    {
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        public string Description { get; set; }
    }

    public class UpdateStockViewModel
    {
        [HiddenInput]
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        public string Description { get; set; }
    }
}
