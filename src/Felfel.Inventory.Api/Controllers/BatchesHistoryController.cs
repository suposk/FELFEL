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
    [Route("api/batches/{batchId}/history")]
    [ApiController]
    public class BatchesHistoryController : ControllerBase
    {
        private readonly ILogger<BatchesHistoryController> _logger;
        private readonly IMapper _mapper;                
        private readonly IRepository<BatchHistory> _repositoryBatchHistory;

        public BatchesHistoryController(
            IMapper mapper,
            IRepository<BatchHistory> repositoryBatchHistory,
            ILogger<BatchesHistoryController> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositoryBatchHistory = repositoryBatchHistory;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
                
        [HttpGet]
        public async Task<ActionResult<IList<BatchHistoryDto>>> GetBatchesHistory(int batchId)
        {
            try
            {
                _logger.LogDebug($"{nameof(GetBatchesHistory)} Started");
                IList<BatchHistoryDto> result = null;
                                
                var repoObj = await _repositoryBatchHistory.GetListFilter(a => a.BatchId == batchId);
                if (repoObj == null)
                    return NotFound();

                result = _mapper.Map<IList<BatchHistoryDto>>(repoObj.OrderByDescending(a => a.CreatedAtUtc));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetBatchesHistory), null);
            }
            return null;
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult<BatchHistoryDto>> GetBatchHitory(int id)
        {
            if (id < 1)
                return BadRequest();

            BatchHistoryDto result = null;
            try
            {
                _logger.LogDebug($"{nameof(GetBatchHitory)} with {id} Started");
                                
                var repoObj = await _repositoryBatchHistory.GetByIdAsync(id);
                if (repoObj == null)
                    return NotFound();

                result = _mapper.Map<BatchHistoryDto>(repoObj);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetBatchHitory), null);
                throw;
            }
        }
    }
}
