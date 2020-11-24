using Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Interfaces
{
    public interface IUserLogic
    {
        void Registartion(string username, string password, string repeatPassword, out string message);
        bool Login(string username, string password, out string message);
        User GetByUsername(string username);
        void Buy(User user, Lot lot);
        void ChangeUsername(string username, string oldUsername, out string message);
        void ChangePassword(string oldPassword, string newPassword, string repeatNewPassword, string username, out string message);
    }
}
