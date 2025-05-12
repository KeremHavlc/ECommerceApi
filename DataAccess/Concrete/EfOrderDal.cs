using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfOrderDal : RepositoryBase<Order, AppDbContext>, IOrderDal
    {
        public EfOrderDal(AppDbContext context) : base(context)
        {
        }
    }

}
