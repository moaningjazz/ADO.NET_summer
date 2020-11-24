using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction.PL.MVC.ViewModel
{
    public class CreateLotVM
    {
        [Required]
        [StringLength(32)]
        public string Title { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        public decimal Cost { get; set; }

        public int IdSeller { get; set; }

        public byte[] Image { get; set; }
    }
}