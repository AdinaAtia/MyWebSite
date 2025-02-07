using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DTO
{
    public record ProductDto(string ProductName, int Price, string Decripition, string ImgPath,string CategoryCategoryName, int ProductsId,int CategoryId);

}