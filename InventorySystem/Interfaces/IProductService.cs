using InventorySystem.DTO.Products;

namespace InventorySystem.Interfaces
{
    public interface IProductService
    {
   
            IEnumerable<ProductDto> GetAll();
            ProductDto GetById(int id);
            void Insert(ProductDto productDto);
            void Update(int id, ProductDto productDto);
            void Delete(int id);
        

    }
}
