using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Helpers;
using ShopWeb.Model;

namespace ShopWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public NotificationItem? LastNotification { get; set; }

        public void OnGet()
        {
            LastNotification = HttpContext.Session.GetObject<NotificationItem>("LastNotification");
        }
    }
}
