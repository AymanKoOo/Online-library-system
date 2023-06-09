﻿using AutoMapper;
using Core.Entites;
using Core.Entites.Books;
using Core.Interfaces;
using Web.Areas.Admin.ViewModels.Book;
using Web.Areas.Admin.ViewModels.BorrowVM;
using Web.Areas.Admin.ViewModels.HoldVM;
using Web.Services;
using Web.ViewModels.BookPage;
using Web.ViewModels.Borrows;
using Web.ViewModels.Holds;
using Web.ViewModels.Home;

namespace Web.Areas.Admin.Factories
{
    public class HoldModelFactory : IHoldModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HoldModelFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<AHoldList> PrepareHoldListModelAsync(int pageSize, int pageNumber)
        {
            var hold = await unitOfWork.hold.GetAllHoldsList(pageSize, pageNumber);

            //using deletate to retrieve data instead of passing data directly to the PreareToGrid function 
            //Overall, using a delegate to retrieve the data is a design pattern that promotes loose coupling and makes the code more flexible and reusable.
            var model = new AHoldList().PrepareToGrid(hold, () =>
            {
                //fill in model values from the entity
                return hold.Data.Select(hold =>
                {
                    var holdModel = mapper.Map<AHoldVM>(hold);
                    holdModel.HoldID = hold.Id;
                    holdModel.BookTitle = hold.Book.Title;
                    holdModel.BookId = hold.Book.Id;
                    holdModel.Email = hold.User.Email;
                    return holdModel;
                });
            });
            return model;
        }

        public async Task<IEnumerable<HoldVM>> PrepareMyHoldsModelClientAsync(ApplicationUser user)
        {
            var holds = await unitOfWork.hold.GetAllHoldsByUser(user.Id);
            List<HoldVM> holdVMs = new List<HoldVM>();

            foreach(var h in holds)
            {
                var picUrl = await unitOfWork.book.GetBookPictureURLByBookID(h.BookId);

                var model = new HoldVM
                {
                    UserName = user.UserName,
                    BookTitle = h.Book.Title,
                    Email = user.Email,
                    HoldPlaced = h.HoldPlaced,
                    BookPicUrl = picUrl,
                    BookSlug = h.Book.Slug
                };
                holdVMs.Add(model);
            }
            return holdVMs;
        }


        public async Task<ABorrowList> PrepareBorrowListModelAsync(int pageSize, int pageNumber)
        {
            var borrowings = await unitOfWork.borrowing.GetAllBorrowList(pageSize, pageNumber);


            //using deletate to retrieve data instead of passing data directly to the PreareToGrid function 
            //Overall, using a delegate to retrieve the data is a design pattern that promotes loose coupling and makes the code more flexible and reusable.
            var model = new ABorrowList().PrepareToGrid(borrowings, () =>
            {
                //fill in model values from the entity
                return borrowings.Data.Select(borrowings =>
                {
                    var borrowModel = mapper.Map<ABorrowVM>(borrowings);
                    return borrowModel;
                });
            });
            return model;
        }

        public async Task<IEnumerable<BorrowVM>> PrepareBorrowClientAsync(ApplicationUser user)
        {
            var borrows = await unitOfWork.borrowing.GetAllBorrowsByUser(user.Id);
            List<BorrowVM> borrowVMS = new List<BorrowVM>();

            foreach (var h in borrows)
            {
                if (h.IsReturned == false)
                {
                    var picUrl = await unitOfWork.book.GetBookPictureURLByBookID(h.BookId);

                    var model = new BorrowVM
                    {
                        BookTitle = h.Book.Title,
                        BorrowedDate = h.BorrowedDate,
                        picUrl = picUrl,
                        DueDate = h.DueDate,
                        IsReturned = h.IsReturned,
                        Slug = h.Book.Slug
                    };
                    borrowVMS.Add(model);
                }
            }
            return borrowVMS;
        }
    }

}
