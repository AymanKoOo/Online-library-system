using Core.Entites;
using Web.Areas.Admin.ViewModels.HoldVM;
using Web.ViewModels.BookPage;
using Web.ViewModels.Holds;

namespace Web.Areas.Admin.Factories
{
    public interface IHoldModelFactory
    {
        public Task<IEnumerable<HoldVM>> PrepareMyHoldsModelClientAsync(ApplicationUser user);
        public Task<AHoldList> PrepareHoldListModelAsync(int pageSize, int pageNumber);

    }
}
