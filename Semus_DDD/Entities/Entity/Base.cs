using System.ComponentModel.DataAnnotations;

namespace Entities.Entity
{
    public class Base
    {
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
