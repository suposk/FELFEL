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
    public class BatchesCollectionController : ControllerBase
    {
        private readonly ILogger<BatchesCollectionController> _logger;
        private readonly IMapper _mapper;
        private readonly IBatchRepository _batchRepository;
        private readonly IRepository<BatchHistory> _repositoryBatchHistory;

        public BatchesCollectionController(
            IMapper mapper,            
            IBatchRepository batchRepository,
            IRepository<BatchHistory> repositoryBatchHistory,
            ILogger<BatchesCollectionController> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _batchRepository = batchRepository ?? throw new ArgumentNullException(nameof(batchRepository));                        
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }              


        [HttpPost]
        public async Task<ActionResult<List<BatchDto>>> Post(List<CreateBatchDto> dto)
        {
            if (dto == null && dto.Count == 0)
                return BadRequest();

            List<BatchDto> result = new List<BatchDto>();
            try
            {
                _logger.LogInformation($"{nameof(Post)} Started");
                foreach(var create in dto)
                {
                    try
                    {
                        var repoObj = _mapper.Map<Batch>(create);                        
                        if (await _batchRepository.AddBatch(repoObj))
                        {
                            var mapped = _mapper.Map<BatchDto>(repoObj);
                            result.Add(mapped);
                        }
                    }
                    catch {}
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Post), null);
                throw;
            }
            return result;
        }
    }
}
