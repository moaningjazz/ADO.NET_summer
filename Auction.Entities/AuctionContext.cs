namespace Auction.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AuctionContext : DbContext
    {
        public AuctionContext()
            : base("name=AuctionConnection")
        {
        }

        public virtual DbSet<Lot> Lots { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.PlacedLots)
                .WithRequired(e => e.Seller)
                .HasForeignKey(e => e.IdSeller)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PurchasedLots)
                .WithOptional(e => e.Buyer)
                .HasForeignKey(e => e.IdBuyer);
        }
    }
}
