using KPMGLoginForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KPMGLoginForm.Models
{
    public interface IUserRepository
    {
        TblUser GetUser(string UserEmail, string Password);

        void AddUser(TblUser user);

        void DeleteUser(TblUser user);

        bool Save();
    }
}
