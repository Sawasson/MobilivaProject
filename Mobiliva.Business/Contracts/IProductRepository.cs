using Mobiliva.Common;
using Mobiliva.DataAccess.Data;
using Mobiliva.Models;

namespace Mobiliva.Business.Contracts
{
    public interface IProductRepository
    {
        public ApiResponse<IEnumerable<ProductDto>> GetAllProduct(string category);

    }
}
