using Auction.BLL.Interfaces;
using Auction.Entities;
using Auction.PL.MVC.App_Start;
using Auction.PL.MVC.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.PL.MVC.Models
{
    public class AuctionModel
    {
        ILotLogic _lotLogic;
        IUserLogic _userLogic;
        IMapper _mapper = AutoMapperConfig.Config.CreateMapper();


        public AuctionModel(ILotLogic lotLogic, IUserLogic userLogic)
        {
            _lotLogic = lotLogic;
            _userLogic = userLogic;
        }

        public IEnumerable<DisplayLotVM> GetAllNotPurchasedLot(string username)
        {
            var lots = _lotLogic.GetAll();
            return _mapper.Map<IEnumerable<DisplayLotVM>>(lots.Where(e => e.Buyer == null && e.Seller.Username != username));
        }

        public void BuyLot(int idLot, string username)
        {
            _userLogic.Buy(_userLogic.GetByUsername(username), _lotLogic.GetById(idLot));
        }

        public bool Authorize(string username, string password)
        {
            return _userLogic.Login(username, password, out var message);
        }

        public void Registration(string username, string password, string repeatPassword)
        {
            _userLogic.Registartion(username, password, repeatPassword, out var message);
        }

        public void AddLot(CreateLotVM lot)
        {
            _lotLogic.Add(lot.Title, lot.Description, lot.IdSeller, lot.Cost, lot.Image, out var message);
        }

        public DisplayUserVM GetUser(string username)
        {
            var user = _userLogic.GetByUsername(username);
            return _mapper.Map<DisplayUserVM>(user);
        }

        public void RemoveLot(int idLot)
        {
            _lotLogic.Remove(_lotLogic.GetById(idLot));
        }

        public void EditLot(string title, string description, int? cost, byte[] image, int idLot)
        {
            _lotLogic.Edit(title, description, cost, image, _lotLogic.GetById(idLot), out var message);
        }

        public IEnumerable<DisplayLotVM> GetUserLots(string username)
        {
            var lots = _lotLogic.GetAll();
            return _mapper.Map<IEnumerable<DisplayLotVM>>(lots.Where(e => e.Seller.Username == username && e.Buyer == null));
        }

        public void ChangePassword(string oldPassword, string newPassword, string repeatNewPassword, string username)
        {
            _userLogic.ChangePassword(oldPassword, newPassword, repeatNewPassword, username, out var message);
        }

        public void ChangeUsername(string newUsername, string oldUsername)
        {
            _userLogic.ChangeUsername(newUsername, oldUsername, out var message);
        }

        public IEnumerable<DisplayLotVM> GetPurchasedLots(string username)
        {
            return _mapper.Map<IEnumerable<DisplayLotVM>>(_lotLogic.GetAll().Where(e => e.Buyer != null && e.Buyer.Username == username));
        }

    }
}