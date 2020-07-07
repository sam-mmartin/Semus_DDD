using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entity
{
    public class Stock : Base
    {
        [DataType(DataType.Date)]
        public DateTime DateRegister { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateUpdate { get; set; }

        public virtual ICollection<StockProducts> StockProducts { get; set; }
    }
}
