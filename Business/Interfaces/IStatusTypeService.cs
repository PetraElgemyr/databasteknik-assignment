using Business.Models;

namespace Business.Interfaces;

public interface IStatusTypeService
{
    Task<ResponseResult<IEnumerable<StatusType>>> GetAllListStatusesAsync();
}