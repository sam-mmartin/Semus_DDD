using System.ComponentModel.DataAnnotations;

namespace Web_DDD_Semus.ViewModels
{
    public class StockViewModel
    {
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        public string Description { get; set; }
    }
}
