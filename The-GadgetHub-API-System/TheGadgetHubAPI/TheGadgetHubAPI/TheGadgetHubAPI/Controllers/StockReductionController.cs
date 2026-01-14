using Microsoft.AspNetCore.Mvc;
using TheGadgetHubAPI.DTO;
using TheGadgetHubAPI.Service;

namespace TheGadgetHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockReductionController : ControllerBase
    {
        private readonly StockReductionService _stockReductionService;

        public StockReductionController(StockReductionService stockReductionService)
        {
            _stockReductionService = stockReductionService;
        }

        // POST /api/StockReduction/Reduce
        [HttpPost("Reduce")]
        public async Task<IActionResult> ReduceStock([FromBody] ReduceStockRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.DistributorName) || request.Items == null || !request.Items.Any())
                return BadRequest("Invalid request data.");

            var success = await _stockReductionService.ReduceStockAsync(request.DistributorName, request.Items);

            if (!success)
                return StatusCode(500, "Failed to reduce stock at distributor.");

            return Ok("Stock reduced successfully.");
        }
    }
}
