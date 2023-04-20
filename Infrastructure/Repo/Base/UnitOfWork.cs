using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo.Base
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _dbContext;

        public IAdminRepo Admin { get; }

        public IPictureRepo picture { get; }

        public IBookRepo book { get; }

        public IBorrowingRepo borrowing { get; }

        public IHoldRepo hold { get; }

        public UnitOfWork(DataContext context)
        {
            this._dbContext = context;
            this.Admin = new AdminRepo(_dbContext);
            this.picture = new PictureRepo(_dbContext);

            this.book = new BookRepo(_dbContext);

            this.borrowing = new BorrowingRepo(_dbContext);

            this.hold = new HoldRepo(_dbContext);

        }

        public void Save()
        {
             _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
         
        }
    }
}
