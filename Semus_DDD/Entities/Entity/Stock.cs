using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entity
{
    public class Stock : Base
    {
        [DataType(DataType.Date)]
        public DateTime DateRegister { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateUpdate { get; set; }
        //[ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
    }
}
