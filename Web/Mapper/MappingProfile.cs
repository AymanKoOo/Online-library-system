using AutoMapper;
using Core.Entites;
using Core.Entites.Books;
using Core.Entites.Borrowing;
using Core.Entites.Hold;
using Infrastructure.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Book;
using Web.Areas.Admin.ViewModels.BorrowVM;
using Web.Areas.Admin.ViewModels.HoldVM;
using Web.ViewModels.BookPage;
using Web.ViewModels.Borrows;
using Web.ViewModels.Home;

namespace Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ABookVM, Book>();
            CreateMap<Book,ABookVM>();

            CreateMap<ABookVMEdit, Book>();
            CreateMap<Book, ABookVMEdit>();

            CreateMap<BookVM, Book>();
            CreateMap<Book, BookVM>();

            CreateMap<BookPageVM, Book>();
            CreateMap<Book, BookPageVM>();

            CreateMap<AHoldVM, Hold>();
            CreateMap<Hold, AHoldVM>();

            CreateMap<ABorrowVM, Borrowing>();
            CreateMap<Borrowing, ABorrowVM>();

            CreateMap<BorrowVM, Borrowing>();
            CreateMap<Borrowing, BorrowVM>();
            
        }
    }
}
