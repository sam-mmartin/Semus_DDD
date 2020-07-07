using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entity
{
    public class Product : Base
    {
        [Display(Name = "Tipo do Produto")]
        public byte Type { get; set; }
        [Display(Name = "Categoria do Produto")]
        public string Category { get; set; }
    }
}
