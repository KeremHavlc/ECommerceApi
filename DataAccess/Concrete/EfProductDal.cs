using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfProductDal : RepositoryBase<Product , AppDbContext>, IProductDal
    {
        public EfProductDal(AppDbContext context) : base(context)
        {
        }
    }
}
