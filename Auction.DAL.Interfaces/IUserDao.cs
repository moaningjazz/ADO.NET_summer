using Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Interfaces
{
    public interface IUserDao
    {
        void Registartion(User user);
        bool Login(User user);
        User GetByUsername(string username);
        void Buy(User user, Lot lot);
        void Edit(User user);
    }
}
