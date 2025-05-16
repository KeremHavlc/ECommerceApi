using Core.Dtos;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Result Add(CategoryDto categoryDto);
        Result Update(CategoryDto categoryDto, Guid categoryId);
        Result Delete(Guid categoryId);
        DataResult<List<Category>> GetAll();
        DataResult<Category> GetById(Guid categoryId);
        DataResult<Category> GetByName(string categoryName);
    }
}
