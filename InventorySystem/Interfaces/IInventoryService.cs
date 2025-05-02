using InventorySystem.DTO;

namespace InventorySystem.Interfaces
{
    public interface IInventoryService
    {
        IEnumerable<InventoryDto> GetAll();
        InventoryDto GetById(int id);
        void Insert(InventoryDto inventory);
        void Update(int id, InventoryDto inventory);
        void Delete(int id);
    }
}
