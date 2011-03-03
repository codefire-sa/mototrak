using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.DataLogic;
using MotoTrak.Entities;
using Codefire.Storm;
using Codefire.Cryptography;

namespace MotoTrak.BusinessLogic
{
    public class UserLogic : BaseLogic
    {
        public UserLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public bool Authenticate(string userCode, string password)
        {
            SetSuccess();

            var hashPassword = EncryptPassword(password);
            using (var db = CreateCatalog())
            {
                var userObj = db.Users.GetByCode(userCode);

                if (userObj == null)
                {
                    SetError(1, "User Name or Password is incorrect.");
                    return false;
                }

                if (userObj.Password != hashPassword)
                {
                    SetError(1, "User Name or Password is incorrect.");
                    return false;
                }

                db.Users.UpdateLastLogin(userObj.Id);

                Ticket.UserId = userObj.Id;
                Ticket.UserCode = userObj.Code;
                Ticket.UserName = userObj.Name;
                Ticket.DealerId = userObj.Dealer.Id;

                return true;
            }
        }

        public UserEntity GetCurrent()
        {
            using (var db = CreateCatalog())
            {
                return db.Users.GetById(Ticket.UserId);
            }
        }

        public void Save(UserEntity userObj)
        {
            using (var db = CreateCatalog())
            {
                db.Users.Save(userObj);
            }
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            SetSuccess();

            var hashOldPassword = EncryptPassword(oldPassword);
            var hashNewPassword = EncryptPassword(newPassword);

            using (var db = CreateCatalog())
            {
                var userObj = db.Users.GetById(Ticket.UserId);

                if (userObj == null)
                {
                    SetError(1, "User could not be retrieved.");
                    return false;
                }

                if (userObj.Password != hashOldPassword)
                {
                    SetError(1, "Your existing password was entered incorrectly.");
                    return false;
                }

                userObj.Password = hashNewPassword;
                userObj.PasswordModifyDate = DateTime.Now;

                db.Users.Save(userObj);
            }

            return true;
        }

        public string EncryptPassword(string password)
        {
            return Hashing.Hash(password, HashingType.SHA256);
        }
    }
}