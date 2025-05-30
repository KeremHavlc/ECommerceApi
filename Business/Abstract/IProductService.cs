using Core.Dtos;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<Result> Add(ProductDto productDto);
        Result Delete(Guid productId);
        Result Update(ProductDto productDto, Guid productId);
        DataResult<List<ProductDto>> GetAll();
        DataResult<ProductDto> GetById(Guid productId);
        DataResult<ProductDto> GetByName(string productName);
        DataResult<List<ProductDto>> GetByCategoryName(string categoryName);
        DataResult<List<ProductDto>> GetByCategoryId(Guid categoryId);
    }
}
