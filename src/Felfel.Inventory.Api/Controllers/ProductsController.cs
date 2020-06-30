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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repositoryProducts;

        public ProductsController(
            IMapper mapper,
            IRepository<Product> repositoryProducts,
            ILogger<ProductsController> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositoryProducts = repositoryProducts ?? throw new ArgumentNullException(nameof(repositoryProducts));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

                
        [HttpGet]
        public async Task<ActionResult<IList<ProductDto>>> Get()
        {
            try
            {
                _logger.LogDebug($"{nameof(Get)} Started");
                IList<ProductDto> result = null;

                var repoObj = await _repositoryProducts.GetListFilter(a => a.IsDeleted == false);                
                if (repoObj == null)
                    return NotFound();

                result = _mapper.Map<IList<ProductDto>>(repoObj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Get), null);
            }
            return null;
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            ProductDto result = null;
            try
            {
                _logger.LogDebug($"{nameof(Get)} with {id} Started");

                var repoObj = await _repositoryProducts.GetByIdAsync(id);                
                if (repoObj == null)
                    return NotFound();
                                
                result = _mapper.Map<ProductDto>(repoObj);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Get), null);
                throw;
            }
        }

    }
}
