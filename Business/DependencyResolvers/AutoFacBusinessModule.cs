using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;

namespace Business.DependencyResolvers
{
    public class AutoFacBusinessModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>();
            builder.RegisterType<EfCartItemDal>().As<ICartItemDal>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();
            builder.RegisterType<EfOrderItemDal>().As<IOrderItemDal>();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();

            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<CartItemManager>().As<ICartItemService>();
            builder.RegisterType<AddressManager>().As<IAddressService>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<OrderItemManager>().As<IOrderItemService>();
            builder.RegisterType<CommentManager>().As<ICommentService>();
        }
    }
}
