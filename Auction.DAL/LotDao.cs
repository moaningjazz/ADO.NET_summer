using Auction.DAL.Interfaces;
using Auction.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL
{
    public class LotDao : ILotDao
    {
        public void Add(Lot lot)
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                auctionContext.Lots.Add(lot);
                auctionContext.SaveChanges();
            }
        }

        public void Edit(Lot lot)
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                auctionContext.Entry<Lot>(lot).State = EntityState.Modified;
                auctionContext.SaveChanges();
            }
        }

        public IEnumerable<Lot> GetAll()
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                return auctionContext.Lots
                    .Include(e => e.Seller)
                    .Include(e => e.Seller.PurchasedLots)
                    .Include(e => e.Seller.PlacedLots)
                    .Include(e => e.Buyer)
                    .Include(e => e.Buyer.PlacedLots)
                    .Include(e => e.Buyer.PurchasedLots)
                    .ToList();
            }
        }

        public Lot GetById(int id)
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                return auctionContext.Lots.Include(e => e.Seller).FirstOrDefault(e => e.Id == id);
            }
        }

        public void Remove(Lot lot)
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                auctionContext.Entry<Lot>(lot).State = EntityState.Deleted;
                auctionContext.SaveChanges();
            }
        }
    }
}
