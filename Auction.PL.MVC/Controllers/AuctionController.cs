using Auction.PL.MVC.Models;
using Auction.PL.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Auction.PL.MVC.Controllers
{
    public class AuctionController : Controller
    {
        AuctionModel _auctionModel;

        public AuctionController(AuctionModel auctionModel)
        {
            _auctionModel = auctionModel;
        }

        public ActionResult Index()
        {
            return View("~/Views/Index.cshtml", _auctionModel.GetAllNotPurchasedLot(User.Identity.Name));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuyLot(int idLot)
        {
            _auctionModel.BuyLot(idLot, User.Identity.Name);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Login()
        {
            return View("~/Views/Login.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(string username, string password)
        {
            if (_auctionModel.Authorize(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(string username, string password, string repeatPassword)
        {
            if (password == repeatPassword)
            {
                _auctionModel.Registration(username, password, repeatPassword);
            }

            return RedirectToAction(nameof(Login));
        }

        public ActionResult LotManagment()
        {
            return View("~/Views/LotManagment.cshtml", _auctionModel.GetUserLots(User.Identity.Name));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLot(string description, string title, int cost, HttpPostedFileBase lotImage)
        {
            MemoryStream target = new MemoryStream();
            lotImage.InputStream.CopyTo(target);
            byte[] data = target.ToArray();

            _auctionModel.AddLot(new CreateLotVM()
            {
                Description = description,
                Cost = cost,
                Title = title,
                IdSeller = _auctionModel.GetUser(User.Identity.Name).Id,
                Image = data
            });

            return Redirect(nameof(LotManagment));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveLot(int idLot)
        {
            _auctionModel.RemoveLot(idLot);

            return Redirect(nameof(LotManagment));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLot(int idLot, string description, string title, int? cost, HttpPostedFileBase lotImage)
        {
            MemoryStream target = new MemoryStream();

            byte[] data;
            if (lotImage != null)
            {
                lotImage.InputStream.CopyTo(target);
                data = target.ToArray();
            }
            else
            {
                data = null;
            }

            _auctionModel.EditLot(title, description, cost, data, idLot);

            return Redirect(nameof(LotManagment));
        }

        public ActionResult MyProfile()
        {
            return View("~/Views/MyProfile.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string oldPassword, string newPassword, string repeatPassword)
        {
            _auctionModel.ChangePassword(oldPassword, newPassword, repeatPassword, User.Identity.Name);

            return Redirect(nameof(MyProfile));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeUsername(string newUsername)
        {
            _auctionModel.ChangeUsername(newUsername, User.Identity.Name);

            return Redirect(nameof(MyProfile));
        }

        public ActionResult GetPurchsedLots()
        {
            return View("~/Views/PurchasedItems.cshtml", _auctionModel.GetPurchasedLots(User.Identity.Name));
        }

        public ActionResult Logout()
        {
            return View("~/Views/LogOut.cshtml");
        }
    }
}