using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Account")]
    public class Account
    {
        [Key][ForeignKey("Employee")]
        public int AccountId { get; set; }
        [DataType(DataType.Password)]
        public string Passwords { get; set; }
        public virtual Employee Employee { get; set; }
    }
}