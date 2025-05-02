using InventorySystem.CQRS.Commands.Products;
using InventorySystem.CQRS.Query.Prouct;
using InventorySystem.DTO;
using InventorySystem.DTO.Products;
using InventorySystem.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductController : ControllerBase
    {
        public IMediator Mediator { get; }

        public ProductController(IMediator mediator)
        {
            Mediator = mediator;
        }


        #region Get By Id


        [HttpGet("{id}")]
        public async Task<ResponseDto<ProductDto>> GetById(int id)
        {
            try
            {
                var product = await Mediator.Send(new GetProductByIdQuery { Id = id });

                if (product == null)
                    return ResponseDto<ProductDto>.Error(Enum.ErrorCode.NotFound, "Product Not Found");

                return ResponseDto<ProductDto>.Succeded(product,"Get Product Succefully");
            }
            catch (Exception ex)
            {
                return ResponseDto<ProductDto>.Error(Enum.ErrorCode.UnExcepectedError, "unexpected error occurred");
            }
        }
        #endregion


        #region Get All
        [HttpGet]
        public async Task<ResponseDto<IEnumerable<ProductDto>>> GetAllProducts()
        {
            try
            {
                var products = await Mediator.Send(new GetAllProductsQuery());

                if (products == null)
                    return ResponseDto<IEnumerable<ProductDto>>.Error(Enum.ErrorCode.NotFound, "The List Is Empty");

                return ResponseDto<IEnumerable<ProductDto>>.Succeded(products,"Get All Successfully");
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<ProductDto>>.Error(Enum.ErrorCode.UnExcepectedError, "unexpected error occurred");
            }
        }

        #endregion


        #region Add
        [HttpPost]
        public async Task<ResponseDto<ProductDto>> AddProduct([FromBody] ProductDto dto)
        {
            try
            {
                var newProduct = await Mediator.Send(new AddProductCommand { product = dto });

                return ResponseDto<ProductDto>.Succeded(newProduct, "Product Added");
            }
            catch (Exception ex)
            {
                return ResponseDto<ProductDto>.Error(Enum.ErrorCode.UnExcepectedError, ex.Message);
            }
        }
        #endregion


        #region Update
        [HttpPut("{id}")]

        public async Task<ResponseDto<ProductDto>> UpdateProduct([FromBody] ProductDto dto , int id)
        {
            try
            {
                var newProduct = await Mediator.Send(new UpdateProductCommand { Product = dto , Id = id });

                return ResponseDto<ProductDto>.Succeded(new ProductDto { Name = newProduct.Name , Price = newProduct.Price ,Description = newProduct.Description}, "Product Updated Succecfully");
            }
            catch (Exception ex)
            {
                return ResponseDto<ProductDto>.Error(Enum.ErrorCode.UnExcepectedError, ex.Message);
            }

        }

        #endregion


        #region Delete
        [HttpDelete("{id}")]

        public async Task<ResponseDto<String>> DeleteProduct(int id)
        {
            try
            {
                var deletedProduct = await Mediator.Send(new DeleteProductCommand { Id = id });

                return ResponseDto<string>.Succeded("Product Deleted Successfully");
            }
            catch (Exception ex)
            {
                return ResponseDto<string>.Error(Enum.ErrorCode.UnExcepectedError, "An unexpected error occurred while deleting the product.");
            }
        }
        #endregion






    }
}
