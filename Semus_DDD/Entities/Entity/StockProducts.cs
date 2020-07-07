using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entity
{
    public class StockProducts
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

        public virtual Product Product { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
