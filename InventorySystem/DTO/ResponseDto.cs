using InventorySystem.DTO;
using InventorySystem.Enum;

namespace InventorySystem.DTO
{
    public class ResponseDto<T>
    {

        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public ErrorCode? ErrorCode { get; set; }

        public static ResponseDto<T> Succeded(T data, string message = "")
        {
            return new ResponseDto<T> { Success = true, Data = data ,Message = message , ErrorCode= Enum.ErrorCode.None};
        }

        public static ResponseDto<T> Error(ErrorCode code, string message)
        {
            return new ResponseDto<T> { Success = false, ErrorCode = code, Message = message };
        }
    }

    
}
