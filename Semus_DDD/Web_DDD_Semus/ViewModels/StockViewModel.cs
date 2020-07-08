using System.ComponentModel.DataAnnotations;

namespace Web_DDD_Semus.ViewModels
{
    public class StockViewModel
    {
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
