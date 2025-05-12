using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfAddressDal : RepositoryBase<Address, AppDbContext>, IAddressDal
    {
        public EfAddressDal(AppDbContext context) : base(context)
        {
        }
    }
}
