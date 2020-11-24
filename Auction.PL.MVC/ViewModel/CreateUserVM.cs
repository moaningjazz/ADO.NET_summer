using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction.PL.MVC.ViewModel
{
    public class CreateUserVM
    {
        [Required]
        [StringLength(32)]
        public string Username { get; set; }

        [Required]
        [MaxLength(32)]
        public byte[] HashPassword { get; set; }
    }
}