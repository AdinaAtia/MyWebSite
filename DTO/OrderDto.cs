using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrderDTO(int OrderId, DateTime OrderDate, int OrderSum, int UserId);
    public record OrderPostDTO(int UserId,  List<OrderItemDTO> OrderItems, int OrderSum);
    public record OrderItemDTO(int? ProductId, int? Quentity);
}
 

