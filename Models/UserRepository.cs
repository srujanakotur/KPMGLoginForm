using KPMGLoginForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPMGLoginForm.Models
{
    public class UserRepository : IUserRepository
    {
        LoginContext context;

        public UserRepository(LoginContext _context)
        {
            this.context = _context;
        }

        public void AddUser(TblUser user)
        {
            context.TblUsers.Add(user);
        }

        public TblUser GetUser(string UserEmail, string Password)
        {
            return context.TblUsers.Where(x => x.UserEmail == UserEmail && x.Password == Password).FirstOrDefault();
        }

        public void DeleteUser(TblUser user)
        {
            context.TblUsers.Remove(user);
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }
    }
}
