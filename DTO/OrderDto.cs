using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrderDTO(int OrderId, DateTime OrderDate, int OrderSum, int UserId,string UserFirstName);
    public record OrderPostDTO(int OrderId, DateTime OrderDate, List<OrderItemDto> OrderItems);
}
 

