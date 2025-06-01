using AutoMapper;
using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        private readonly ICategoryDal _categoryDal;
        public ProductManager(IProductDal productDal, IMapper mapper , ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _mapper = mapper;
            _categoryDal = categoryDal;
        }
        public async Task<Result> Add(ProductDto productDto)
        {
            var existingProduct = _productDal.Get(p => p.Name == productDto.Name);
            if (existingProduct != null)
                return new ErrorResult("Product already available!");

            var product = _mapper.Map<Product>(productDto);
            _productDal.Add(product);

            return new SuccessResult("Product added successfully!");
        }

        public Result Delete(Guid productId)
        {
            var product = _productDal.Get(p => p.Id == productId);
            if(product == null)
            {
                return new ErrorResult("Product not found!");
            }
            _productDal.Delete(product);
            return new SuccessResult("Product deleted successfully!");
        }

        public DataResult<List<ProductDto>> GetAll()
        {
            var products = _productDal.GetAll();
            if (products == null)
            {
                return new ErrorDataResult<List<ProductDto>>("Product not found!");
            }
            var productDtos = _mapper.Map<List<ProductDto>>(products);

           
            foreach (var product in productDtos)
            {       
                if (!string.IsNullOrEmpty(product.Image))
                {
                    product.Image = "https://localhost:7042/images/" + product.Image;
                }
            }
            return new SuccessDataResult<List<ProductDto>>(productDtos, "Product listed successfully!");
        }
        public DataResult<List<ProductDto>> GetByCategoryId(Guid categoryId)
        {
            var category = _categoryDal.Get(c => c.Id == categoryId);
            if(category == null)
            {
                return new ErrorDataResult<List<ProductDto>>("Category not found!");
            }
            var products = _productDal.GetAll(p => p.CategoryId == categoryId);
            if(products == null)
            {
                return new ErrorDataResult<List<ProductDto>>("No product found on this categoryId!");
            }
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            foreach (var product in productDtos)
            {
                if (!string.IsNullOrEmpty(product.Image))
                {
                    product.Image = "https://localhost:7042/images/" + product.Image;
                }
            }
            return new SuccessDataResult<List<ProductDto>>(productDtos, "Product found successfully in this CategoryId!");
        }

        public DataResult<List<ProductDto>> GetByCategoryName(string categoryName)
        {
            var category = _categoryDal.Get(c => c.Name == categoryName);
            if(category == null)
            {
                return new ErrorDataResult<List<ProductDto>>("Category Not found!");
            }
            var products = _productDal.GetAll(p => p.CategoryId == category.Id);
            if(products == null)
            {
                return new ErrorDataResult<List<ProductDto>>("No product found on this categoryName!");
            }
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            foreach (var product in productDtos)
            {
                if (!string.IsNullOrEmpty(product.Image))
                {
                    product.Image = "https://localhost:7042/images/" + product.Image;
                }
            }

            return new SuccessDataResult<List<ProductDto>>(productDtos, "Product found successfully in this CategoryName!");
        }

        public DataResult<ProductDto> GetById(Guid productId)
        {
            var product = _productDal.Get(p => p.Id == productId);
            if(product == null)
            {
                return new ErrorDataResult<ProductDto>("Product not found!");
            }
            var productDtos = _mapper.Map<ProductDto>(product);
            if (!string.IsNullOrEmpty(productDtos.Image))
            {
                productDtos.Image = "https://localhost:7042/images/" + productDtos.Image;
            }

            return new SuccessDataResult<ProductDto>(productDtos, "Product found successfully!");
        }

        public DataResult<ProductDto> GetByName(string productName)
        {
            var product = _productDal.Get(p => p.Name == productName);
            if(product == null)
            {
                return new ErrorDataResult<ProductDto>("Product not found!");
            }
            var productDtos = _mapper.Map<ProductDto>(product);

            return new SuccessDataResult<ProductDto>(productDtos, "Product found successfully!");
        }

        public Result Update(ProductDto productDto, Guid productId)
        {
            var product = _productDal.Get(p => p.Id == productId);
            if(product == null)
            {
                return new ErrorResult("Product not found!");
            }
            var existingProduct = _productDal.Get(p => p.Name == productDto.Name && p.Id != productId);
            if(existingProduct != null)
            {
                return new ErrorResult("Another product with this name already exists!");
            }

            _mapper.Map(productDto, product);
            _productDal.Update(product);
            return new SuccessResult("Product updated successfully!");
        }
    }
}
