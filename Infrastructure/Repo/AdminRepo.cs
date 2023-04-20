using Core.Entites;
using Core.Entites.others;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class AdminRepo : GenericRepo<ApplicationUser>, IAdminRepo
    {
        private readonly DataContext _dbcontext;

        public AdminRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }
       
        public void AddUser(ApplicationUser model)
        {
        }

        public void DeleteUser(ApplicationUser model)
        {
            _dbcontext.Users.Remove(model);
        }

        public void EditUser(ApplicationUser model)
        {
            _dbcontext.Users.Update(model);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserWithRoles> GetAllUsersWithRole()
        {
            var users = from ur in _dbcontext.UserRoles
                            join u in _dbcontext.Users on ur.UserId equals u.Id
                            join a in _dbcontext.Roles on ur.RoleId equals a.Id
                            where a.NormalizedName == "USER"
                            select new UserWithRoles
                            {   
                                UserId = u.Id,
                                UserName = u.UserName,
                                Email = u.Email,
                                Role = a.Name
                            };
            return users;
        }

        public async Task<ApplicationUser> GetUser(string email)
        {
            return await _dbcontext.Users.FirstOrDefaultAsync(x=>x.Email==email);
        }
        public async Task<ApplicationUser> GetUserByID(string id)
        {
            return await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
