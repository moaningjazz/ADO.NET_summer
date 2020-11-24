using Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Interfaces
{
    public interface ILotLogic
    {
        void Add(string title, string description, int idSeller, decimal cost, byte[] image, out string message);
        void Edit(string newTitle, string newDescription, decimal? newCost, byte[] newImage, Lot lotForEdit, out string message);
        IEnumerable<Lot> GetAll();
        Lot GetById(int id);
        void Remove(Lot lot);
    }
}
