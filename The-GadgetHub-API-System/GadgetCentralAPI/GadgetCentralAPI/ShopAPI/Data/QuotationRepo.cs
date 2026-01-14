using GadgetCentralAPI.DTO;
using GadgetCentralAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GadgetCentralAPI.Data
{
    public class QuotationRepo
    {
        private readonly AppDBContext _context;
        public QuotationRepo(AppDBContext context) => _context = context;

        public async Task<(Quotation?, string?)> CreateAutoQuotationAsync(string customerName, List<QuotationItemDto> items)
        {
            var productIds = items.Select(i => i.ProductId).ToList();
            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            if (products.Count != items.Count)
                return (null, "One or more products not found.");

            var quotationItems = new List<QuotaionItem>();
            decimal totalAmount = 0;
            DateTime latestDeliveryDate = DateTime.MinValue;

            foreach (var item in items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product == null) continue;

                var unitPrice = product.Price;
                var totalPrice = unitPrice * item.Quantity;

                quotationItems.Add(new QuotaionItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = unitPrice,
                    TotalPrice = totalPrice
                });

                totalAmount += totalPrice;

                if (product.DeliveryDate > latestDeliveryDate)
                    latestDeliveryDate = product.DeliveryDate;
            }

            var quotation = new Quotation
            {
                CustomerName = customerName,
                Items = quotationItems,
                TotalAmount = totalAmount,
                CreatedAt = DateTime.UtcNow,
                 DeliveryDate = latestDeliveryDate
            };

            _context.Quotations.Add(quotation);
            await _context.SaveChangesAsync();

            return (quotation, null);
        }



        public async Task<List<Quotation>> GetAllAsync() =>
            await _context.Quotations.Include(q => q.Items).ThenInclude(i => i.Product).ToListAsync();

        public async Task<Quotation?> GetByIdAsync(int id) =>
            await _context.Quotations.Include(q => q.Items).ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(q => q.Id == id);

        public async Task<bool> DeleteAsync(int id)
        {
            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation == null) return false;

            _context.Quotations.Remove(quotation);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}