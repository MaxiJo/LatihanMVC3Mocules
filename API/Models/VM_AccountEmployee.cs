using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class VM_AccountEmployee
    {
        public int EmployeeId { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }
        //[Index(IsUnique = true)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Password)]
        public string Passwords { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "we need to confirm ur password")]
        [CompareAttribute("Passwords",ErrorMessage="password doesn't match")]
        public string ConfirmPasswords { get; set; }
    }
}