using Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Interfaces
{
    public interface ILotDao
    {
        void Add(Lot lot);
        IEnumerable<Lot> GetAll();
        Lot GetById(int id);
        void Remove(Lot lot);
        void Edit(Lot lot);
    }
}
