using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : RepositoryBase<Category, AppDbContext>, ICategoryDal
    {
        public EfCategoryDal(AppDbContext context) : base(context)
        {
        }
    }

}
