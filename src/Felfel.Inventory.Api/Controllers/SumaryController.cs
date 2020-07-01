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
    public class SumaryController : ControllerBase
    {
        private readonly ILogger<SumaryController> _logger;
        private readonly IMapper _mapper;
        private readonly ISummaryRepository _summaryRepository;

        public SumaryController(
            IMapper mapper,
            ISummaryRepository summaryRepository,
            ILogger<SumaryController> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _summaryRepository = summaryRepository ?? throw new ArgumentNullException(nameof(summaryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IList<BatchDto>>> Get(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
                return BadRequest("state (ex. Fresh, ExpiresToday, Expired) must be passed as parameter");
                        
            if (!Enum.TryParse<FreshnesState>(state, true, out FreshnesState freshnesState))
                return BadRequest($"state is not supported state (ex. Fresh, ExpiresToday, Expired");

            try
            {
                _logger.LogDebug($"{nameof(Get)} Started");
                IList<BatchDto> result = null;

                var repoObj = await _summaryRepository.GetFreshness(freshnesState);
                if (repoObj == null)
                    return NotFound();

                result = _mapper.Map<IList<BatchDto>>(repoObj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Get), null);
            }
            return null;
        }             

    }
}
