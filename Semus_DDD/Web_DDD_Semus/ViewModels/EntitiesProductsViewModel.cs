using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web_DDD_Semus.ViewModels
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Description { get; set; }
        [HiddenInput]
        public byte Type { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo categoria é obrigatório")]
        public string Category { get; set; }
    }

    public class StockProductsViewModel
    {
        public int ProductID { get; set; }
        public int StockID { get; set; }

        [Display(Name = "Quantidade")]
        public int QuantityTotal { get; set; }
        [Display(Name = "Última Entrada")]
        public int Quant_Input { get; set; }
        [Display(Name = "Última Saída")]
        public int Quant_Output { get; set; }
        public int Quant_Shortage { get; set; }
        [Display(Name = "Data de Entrada"), DataType(DataType.Date)]
        public DateTime DateInput { get; set; }
        [Display(Name = "Data de Saida"), DataType(DataType.Date)]
        public DateTime DateOutput { get; set; }

        public virtual ProductViewModel Product { get; set; }
        public virtual StockViewModel Stock { get; set; }
    }
}
