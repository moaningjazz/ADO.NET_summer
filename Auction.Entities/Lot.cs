namespace Auction.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lot")]
    public partial class Lot
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Title { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        public decimal Cost { get; set; }

        public int IdSeller { get; set; }

        public int? IdBuyer { get; set; }

        public byte[] Image { get; set; }

        public virtual User Seller { get; set; }

        public virtual User Buyer { get; set; }
    }
}
