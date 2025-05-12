using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfOrderItemDal : RepositoryBase<OrderItem, AppDbContext>, IOrderItemDal
    {
        public EfOrderItemDal(AppDbContext context) : base(context)
        {
        }
    }
}
