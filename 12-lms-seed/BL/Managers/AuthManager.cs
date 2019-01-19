using BL.Managers.Interfaces;
using BL.Util;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class AuthManager : IAuthManager
    {

        public User FindUser(string userName, string passwordHash)
        {
            IAuthRepository authRepo = new AuthRepository();
            return authRepo.FindUser(userName, HashHelper.GetMD5HashData(passwordHash));
        }
    }
}
