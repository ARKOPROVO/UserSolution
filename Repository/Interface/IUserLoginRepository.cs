using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSolution.Models;

namespace UserSolution.Repository.Interface
{
    interface IUserLoginRepository
    {
        public User ConfirmLogin(string userid, string password);
    }
}
