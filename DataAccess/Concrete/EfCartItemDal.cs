using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfCartItemDal : RepositoryBase<CartItem, AppDbContext>, ICartItemDal
    {
        public EfCartItemDal(AppDbContext context) : base(context)
        {
        }
    }
}
