using Auction.BLL.Interfaces;
using Auction.DAL.Interfaces;
using Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL
{
    public class LotLogic : ILotLogic
    {
        private ILotDao _lotDao;
        public LotLogic(ILotDao lotDao) => _lotDao = lotDao;

        public void Add(string title, string description, int idSeller, decimal cost, byte[] image, out string message)
        {
            if (title == null || description == null)
            {
                message = "Lots add error";
                return;
            }
            else if (title.Length <= 4 || title.Length >= 32)
            {
                message = "The title must be more than 4 characters and less than 32 characters";
                return;
            }
            else if (description.Length <= 4 || description.Length >= 250)
            {
                message = "The title must be more than 4 characters and less than 250 characters";
                return;
            }
            else if (image == null)
            {
                message = "Image is empty";
                return;
            }

            message = "Lot added";
            _lotDao.Add(new Lot()
            {
                Title = title,
                Description = description,
                IdSeller = idSeller,
                Cost = cost,
                Image = image
            });
        }

        public void Edit(string newTitle, string newDescription, decimal? newCost, byte[] newImage, Lot lotForEdit, out string message)
        {
            if (newTitle == null || newTitle == null)
            {
                message = "Lots edit error";
                return;
            }
            else if (newTitle != "" && (newTitle.Length <= 4 || newTitle.Length >= 32))
            {
                message = "The title must be more than 4 characters and less than 32 characters";
                return;
            }
            else if (newDescription != "" && (newDescription.Length <= 4 || newDescription.Length >= 250))
            {
                message = "The description must be more than 4 characters and less than 250 characters";
                return;
            }

            message = "Lot edit";
            lotForEdit.Title = newTitle != "" ? newTitle : lotForEdit.Title;
            lotForEdit.Description = newDescription != "" ? newDescription : lotForEdit.Description;
            lotForEdit.Cost = newCost != null ? newCost.Value : lotForEdit.Cost;
            lotForEdit.Image = newImage != null ? newImage : lotForEdit.Image;
            _lotDao.Edit(lotForEdit);
        }

        public IEnumerable<Lot> GetAll()
        {
            return _lotDao.GetAll();
        }

        public Lot GetById(int id)
        {
            return _lotDao.GetById(id);
        }

        public void Remove(Lot lot)
        {
            _lotDao.Remove(lot);
        }
    }
}
