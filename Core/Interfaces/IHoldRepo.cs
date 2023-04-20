using AyyBlog.ViewModel;
using Core.Entites.Books;
using Core.Entites.Hold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IHoldRepo : IGenericRepo<Hold>
    {
        public Task<bool> CheckUserNOHoldSameBook(string userID, Book bookid);
        public Task UserHoldBook(string userID, Book book);
        public Task<IEnumerable<Hold>> GetAllHoldsByUser(string userId);
        public Task<IEnumerable<Hold>> GetAllHolds();
        public Task UserCancelHoldBook(string userID, Book book);
        public Task<PagedList<Hold>> GetAllHoldsList(int pageSize, int pageNumber);
        public Task<Hold> GetHoldByID(int id);
    }
}
