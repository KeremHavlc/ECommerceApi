using AutoMapper;
using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        public Result Add(CategoryDto categoryDto)
        {
            var existingCategory = _categoryDal.Get(c => c.Name == categoryDto.Name);
            if(existingCategory != null)
            {
                return new ErrorResult("Category name already used!");
            }
            var newCategory = _mapper.Map<Category>(categoryDto);
            _categoryDal.Add(newCategory);
            return new SuccessResult("Category added succesfully!");
        }

        public Result Delete(Guid categoryId)
        {
            var category = _categoryDal.Get(c => c.Id == categoryId);
            if(category == null)
            {
                return new ErrorResult("Category not found!");
            }
            _categoryDal.Delete(category);
            return new SuccessResult("Category deleted successfully!");
        }

        public DataResult<List<Category>> GetAll()
        {
            var categories = _categoryDal.GetAll();
            if(categories == null)
            {
                return new ErrorDataResult<List<Category>>("Category not found!");
            }
            return new SuccessDataResult<List<Category>>(categories, "Category listed successfully!");
        }

        public DataResult<Category> GetById(Guid categoryId)
        {
            var category = _categoryDal.Get(c => c.Id == categoryId);
            if(category == null)
            {
                return new ErrorDataResult<Category>("Category not found!");
            }
            return new SuccessDataResult<Category>(category, "Category found successfully!");
        }

        public DataResult<Category> GetByName(string categoryName)
        {
            var category = _categoryDal.Get(c => c.Name == categoryName);
            if(category == null)
            {
                return new ErrorDataResult<Category>("Category not found!");
            }
            return new SuccessDataResult<Category>(category,"Category found successfully!");
        }

        public Result Update(CategoryDto categoryDto, Guid categoryId)
        {
            var category = _categoryDal.Get(c => c.Id == categoryId);
            if(category == null)
            {
                return new ErrorResult("Category not found!");
            }
            var existingCategory = _categoryDal.Get(c => c.Name == categoryDto.Name && c.Id != categoryId);
            if(existingCategory != null)
            {
                return new ErrorResult("Category name already used!");
            }
            _mapper.Map(categoryDto, category);
            _categoryDal.Update(category);
            return new SuccessResult("Category updated successfully!");            
        }
    }
}
