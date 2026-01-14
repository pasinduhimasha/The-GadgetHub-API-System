using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheGadgetHubAPI.Data;
using TheGadgetHubAPI.Models;
using TheGadgetHubAPI.DTO;
using AutoMapper;

namespace TheGadgetHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMapper mapper;
        private ProductRepo repo;

        public ProductController(IMapper _mapper, ProductRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }
        [HttpPost]
        public ActionResult CreateProduct(ProductWriteDTO writeDTO)
        {
            var product = mapper.Map<Product>(writeDTO);
            if (repo.Create(product))
                return Ok();
            return BadRequest();
            
        }
        [HttpGet]
        public ActionResult<List<ProductReadDTO>> GetProducts()
        {
            var products = repo.GetProducts();
            return Ok(mapper.Map<List<ProductReadDTO>>(products));
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct
            (int id,ProductWriteDTO dto)
        {
            var product=mapper.Map<Product>(dto);
            product.Id = id;
            if (repo.Update(product))
                return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        { 
            var product=repo.GetProduct(id);
            if (product != null)
            {
                repo.Remove(product);
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public ActionResult GetProductByID(int id)
        {
            var product = repo.GetProduct(id);
            if(product != null)
                return Ok(mapper.Map<ProductReadDTO>(product));
            return BadRequest();
        }
    }
}
