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
    public class UserDao : IUserDao
    {
        public void Buy(User user, Lot lot)
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                lot.Buyer = user;
                lot.IdBuyer = user.Id;
                auctionContext.Entry<Lot>(lot).State = EntityState.Modified;
                auctionContext.SaveChanges();
            }
        }

        public void Edit(User user)
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                auctionContext.Entry<User>(user).State = EntityState.Modified;
                auctionContext.SaveChanges();
            }
        }

        public User GetByUsername(string username)
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                return auctionContext.Users.Include(e => e.PlacedLots)
                    .Include(e => e.PurchasedLots)
                    .FirstOrDefault(e => e.Username == username);
            }
        }

        public bool Login(User user)
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                return auctionContext.Users.Any(e => 
                e.HashPassword == user.HashPassword && 
                e.Username == user.Username);
            }
        }

        public void Registartion(User user)
        {
            using (AuctionContext auctionContext = new AuctionContext())
            {
                auctionContext.Users.Add(user);
                auctionContext.SaveChanges();
            }
        }
    }
}
