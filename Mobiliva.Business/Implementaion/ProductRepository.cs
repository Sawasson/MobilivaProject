using AutoMapper;
using Mobiliva.Business.Contracts;
using Mobiliva.Business.Event;
using Mobiliva.Common;
using Mobiliva.Common.Cache;
using Mobiliva.Common.EventBus;
using Mobiliva.DataAccess.Data;
using Mobiliva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Business.Implementaion
{
    public class ProductRepository : IProductRepository
    {
        private readonly MobilivaDbContext _dbContext;

        private readonly IMapper _mapper;

        private readonly ICacheService _cacheService;

        IEventBus eventBus;

        public ProductRepository(MobilivaDbContext dbContext, IMapper mapper, IEventBus eventBus, ICacheService cacheService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            this._cacheService = cacheService;
            this.eventBus = eventBus;
        }

        public ApiResponse<IEnumerable<ProductDto>> GetAllProduct(string category)
        {
            var products = _cacheService.Get("Producs", () => GetAllProducts());

            try
            {             

                if (category == null)
                {
                    products = _dbContext.Products;

                    var productDtos = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);


                    return new ApiResponse<IEnumerable<ProductDto>>(Status.Success, ResponseConstant.RecordFound, productDtos, null);
                }
                else
                {
                    products = products.Where(x => x.Category.Contains(category));

                    var productDtos = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

                    return new ApiResponse<IEnumerable<ProductDto>>(Status.Success, ResponseConstant.RecordFound, productDtos, null);
                }
                
                
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<ProductDto>>(Status.Failed, ResponseConstant.RecordNotFound);
            }
        }

        private IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

    }
}
