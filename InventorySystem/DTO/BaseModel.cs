using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.DTO
{
    public class BaseModel
    {
        [Key]

        public int Id { set; get; }
    }
}
