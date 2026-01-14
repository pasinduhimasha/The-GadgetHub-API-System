using Microsoft.AspNetCore.Mvc;
using TheGadgetHubAPI.DTO;
using TheGadgetHubAPI.Models;
using TheGadgetHubAPI.Service;

namespace TheGadgetHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly QuotationService _quotationService;
        private readonly StockReductionService _stockReductionService;

        public OrdersController(
            QuotationService quotationService,
            StockReductionService stockReductionService)
        {
            _quotationService = quotationService;
            _stockReductionService = stockReductionService;
        }

        // POST /api/Orders
        [HttpPost]
        public async Task<ActionResult<Guid>> PlaceOrder([FromBody] OrderRequestDto request)
        {
            var bestQuotation = await _quotationService.GetBestQuotationAsync(request);

            if (bestQuotation == null)
                return StatusCode(503, "No distributor services are currently available or no matching products found.");

            var notification = new OrderNotification
            {
                Supplier = bestQuotation.Supplier,
                Items = bestQuotation.Items,
                DeliveryDate = bestQuotation.DeliveryDate

            };

            var notificationId = NotificationStore.AddNotification(notification);

            return Ok(notificationId);  // Return only the Notification ID (GUID)
        }

        // GET /api/Orders/{id}/Notification
        [HttpGet("{id}/Notification")]
        public ActionResult<OrderNotification> GetOrderNotification(Guid id)
        {
            var notification = NotificationStore.GetNotification(id);

            if (notification == null)
                return NotFound("Notification not found.");

            return Ok(notification);
        }

        // POST /api/Orders/{id}/BuyNow
     
    }
}
