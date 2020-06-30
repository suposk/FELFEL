using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Felfel.Inventory.Domain;
using Felfel.Inventory.Entities;
using Felfel.Inventory.Services;
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
                _logger.LogInformation($"{nameof(GetBatches)} Started");
                IList<BatchDto> result = null;

                //var repoObj = await _repositoryBatch.GetListFilter(a => a.IsDeleted == false);
                var repoObj = await _batchRepository.GetListFilter<Batch>(a => a.IsDeleted == false);
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
                _logger.LogInformation($"{nameof(GetBatch)} with {id} Started");

                //var repoObj = await _batchRepository.GetByIdAsync(id);
                var repoObj = await _batchRepository.GetById<Batch>(id);
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BatchesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
