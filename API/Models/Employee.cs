using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }
        //[Index(IsUnique = true)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        public DateTime BirthDate { get; set; }
        public virtual Account Account { get; set; }
    }
}