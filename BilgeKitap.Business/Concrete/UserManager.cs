﻿using BilgeKitap.Business.Abstract;
using BilgeKitap.Core.Entities.Concrete;
using BilgeKitap.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
