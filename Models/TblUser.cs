using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KPMGLoginForm.Models
{
    [Table("tblUsers")]
    public partial class TblUser
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(40)]
        public string Username { get; set; }
        [StringLength(40)]
        public string Password { get; set; }
        [StringLength(40)]
        public string UserEmail { get; set; }
    }
}
