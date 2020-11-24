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
    public class UserLogic : IUserLogic
    {
        private IUserDao _userDao;
        public UserLogic(IUserDao userDao) => _userDao = userDao;

        public void Buy(User user, Lot lot)
        {
            _userDao.Buy(user, lot);
        }

        public void ChangePassword(string oldPassword, string newPassword, string repeatNewPassword, string username, out string message)
        {
            if (newPassword == null ||
                oldPassword == null ||
                repeatNewPassword == null ||
                username == null)
            {
                message = "Password change error";
                return;
            }
            else if (!Login(username, oldPassword, out message))
            {
                message = "Invalid password";
                return;
            }
            else if ((newPassword.Length <= 4 ||
                repeatNewPassword.Length >= 32))
            {
                message = "The password must be more than 4 characters and less than 32 characters";
                return;
            }
            else if (newPassword != repeatNewPassword)
            {
                message = "Password not equal";
                return;
            }

            message = "Password change";
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashPassword = Encoding.Default.GetBytes(newPassword);
                User user = _userDao.GetByUsername(username);
                user.HashPassword = hashPassword;
                _userDao.Edit(user);
            }
        }

        public void ChangeUsername(string username, string oldUsername, out string message)
        {
            User user;
            if (username == null ||
                oldUsername == null ||
                GetByUsername(oldUsername) == null)
            {
                message = "Useraname change error";
                return;
            }
            if (GetByUsername(username) != null)
            {
                message = "Username already used";
                return;
            }
            message = "Change success";
            user = GetByUsername(oldUsername);
            user.Username = username;
            _userDao.Edit(user);
        }

        public User GetByUsername(string username)
        {
            return _userDao.GetByUsername(username);
        }

        public bool Login(string username, string password, out string message)
        {
            if (username == null || password == null)
            {
                message = "Error registartion";
                return false;
            }
            else if (!(username.Length >= 4 && username.Length <= 32))
            {
                message = "The username must be more than 4 characters and less than 32 characters";
                return false;
            }
            else if (!(password.Length >= 4 && password.Length <= 32))
            {
                message = "The password must be more than 4 characters and less than 32 characters";
                return false;
            }

            User user;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashPassword = Encoding.Default.GetBytes(password);
                user = new User() { HashPassword = hashPassword, Username = username};
            }

            if (_userDao.Login(user))
            {
                message = "Login success";
                return true;
            }
            else
            {
                message = "Invalid password or login";
                return false;
            }
        }

        public void Registartion(string username, string password, string repeatPassword, out string message)
        {
            if (username == null || password == null || repeatPassword == null)
            {
                message = "Error registartion";
                return;
            }
            else if (!(username.Length >= 4 && username.Length <= 32))
            {
                message = "The username must be more than 4 characters and less than 32 characters";
                return;
            }
            else if (!(password.Length >= 4 && password.Length <= 32))
            {
                message = "The password must be more than 4 characters and less than 32 characters";
                return;
            }
            else if (!(password == repeatPassword))
            {
                message = "Passwords don't match";
                return;
            }

            User user;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashPassword = Encoding.Default.GetBytes(password);
                user = new User() { HashPassword = hashPassword, Username = username };
            }

            if (GetByUsername(username) == null)
            {
                message = "Registartion success";
                _userDao.Registartion(user);
            }
            else
            {
                message = "User already exist";
            }
        }
    }
}
