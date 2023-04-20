using Core.Entites;
using Core.Entites.others;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public interface IAdminRepo : IGenericRepo<ApplicationUser>
    {
        void AddUser(ApplicationUser model);
        void DeleteUser(ApplicationUser model);
        void EditUser(ApplicationUser model);
        IEnumerable<ApplicationUser> GetAllUsers();
        public IQueryable<UserWithRoles> GetAllUsersWithRole();
        public Task<ApplicationUser> GetUser(string email);
        public Task<ApplicationUser> GetUserByID(string id);

    }
}
