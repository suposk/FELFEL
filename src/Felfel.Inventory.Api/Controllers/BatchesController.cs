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
    public class BatchesController : ControllerBase
    {
        private readonly ILogger<BatchesController> _logger;
        private readonly IMapper _mapper;
        private readonly IBatchRepository _batchRepository;

        //private readonly IRepository<Batch> _repositoryBatch;
        private readonly IRepository<BatchHistory> _repositoryBatchHistory;

        public BatchesController(
            IMapper mapper,
            //IRepository<Batch> repositoryBatch,
            IBatchRepository batchRepository,
            IRepository<BatchHistory> repositoryBatchHistory,
            ILogger<BatchesController> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _batchRepository = batchRepository;
            //_repositoryBatch = repositoryBatch;
            _repositoryBatchHistory = repositoryBatchHistory;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        // GET: api/<BatchesController>
        [HttpGet]
        public async Task<ActionResult<IList<BatchDto>>> GetBatches()
        {
            try
            {
                _logger.LogDebug($"{nameof(GetBatches)} Started");
                IList<BatchDto> result = null;

                //var repoObj = await _repositoryBatch.GetListFilter(a => a.IsDeleted == false);
                var repoObj = await _batchRepository.GetFilter(a => a.IsDeleted == false);
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

        // GET api/<BatchesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BatchDto>> GetBatch(int id)
        {
            if (id < 1)
                return BadRequest();

            BatchDto result = null;
            try
            {
                _logger.LogDebug($"{nameof(GetBatch)} with {id} Started");

                var repoObj = await _batchRepository.GetById(id);
                if (repoObj == null)
                    return NotFound();
                                
                result = _mapper.Map<BatchDto>(repoObj);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetBatch), null);
                throw;
            }
        }

        // POST api/<BatchesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BatchesController>/5
        [HttpPut]
        public async Task<ActionResult<BatchDto>> Put(UpdateBatchDto dto)
        {
            if (dto == null || dto.BatchId < 1 || dto.Units < 0)
                return BadRequest();

            if (dto.Units == 0)
                return NoContent();

            try
            {
                _logger.LogDebug($"{nameof(Put)} Started");

                //var repoObj = await _genericRepository.GetById<MessageDetail>(dto.MessageDetailId);
                var repoObj = await _batchRepository.GetByIdGeneric<Batch>(dto.BatchId);
                if (repoObj == null)
                    return NotFound();

                var updated = await _batchRepository.UpdateUnits(dto.BatchId, dto.Units, dto.Description, dto.DecrementUnits);
                if (updated != null)
                {
                    var result = _mapper.Map<BatchDto>(updated);                
                    return result;
                }
                else                
                    return this.StatusCode(StatusCodes.Status409Conflict, "Failed to update due to inconsistancy.");                    
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Put), null);
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error during Update, {ex.Message}");
                //throw;
            }            
        }

        // DELETE api/<BatchesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
