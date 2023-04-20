using Infrastructure.Repo;
using System;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepo Admin { get; }

        IPictureRepo picture { get; }
        IBookRepo book { get; } 
        IBorrowingRepo borrowing { get; }
        IHoldRepo hold { get; }     
        void Save();
        Task SaveAsync();

    }
}
