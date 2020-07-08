using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_DDD_Semus.ViewModels
{
    public class StockViewModel
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StockProductsViewModel> StockProducts { get; set; }
    }

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
