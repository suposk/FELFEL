using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Felfel.Inventory.Domain;
using Felfel.Inventory.Entities;
using Felfel.Inventory.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Felfel.Inventory.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/products/{productId}/batches")]
    [ApiController]
    public class ProductBatchesController : ControllerBase
    {
        private readonly ILogger<ProductBatchesController> _logger;
        private readonly IMapper _mapper;
        private readonly IBatchRepository _batchRepository;

        public ProductBatchesController(
            IMapper mapper,            
            IBatchRepository batchRepository,            
            ILogger<ProductBatchesController> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _batchRepository = batchRepository ?? throw new ArgumentNullException(nameof(batchRepository));                        
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        
        [HttpGet]
        public async Task<ActionResult<IList<BatchDto>>> GetBatches(int productId)
        {
            try
            {
                _logger.LogDebug($"{nameof(GetBatches)} Started");
                IList<BatchDto> result = null;
                                
                var repoObj = await _batchRepository.GetFilter(a => a.IsDeleted == false && a.ProductId == productId);
                if (repoObj == null)
                    return NotFound();

                result = _mapper.Map<IList<BatchDto>>(repoObj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetBatches), null);
            }
            return null;
        }
    }
}
