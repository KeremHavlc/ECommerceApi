using Core.Dtos;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICartItemService
    {
        Result Add(CartItemDto cartItemDto);
        Result Delete(Guid cartItemId);
        Result ClearCart(Guid userId);
        DataResult<List<CartItemDto>> GetListByUserId(Guid userId);
        
    }
}
