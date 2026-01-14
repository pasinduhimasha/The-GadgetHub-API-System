using AutoMapper;
using GadgetCentralAPI.Data;
using GadgetCentralAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GadgetCentralAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class QuotationController : ControllerBase
    {
        private readonly QuotationRepo _repo;
        private readonly IMapper _mapper;

        public QuotationController(QuotationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<QuotationResponseDto>> CreateAutoQuotation(QuotationCreateDTO dto)
        {
            var (quotation, error) = await _repo.CreateAutoQuotationAsync(dto.CustomerName, dto.Items);
            if (quotation == null)
                return BadRequest(new { message = error });

            var result = _mapper.Map<QuotationResponseDto>(quotation);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuotationResponseDto>> GetById(int id)
        {
            var quotation = await _repo.GetByIdAsync(id);
            if (quotation == null) return NotFound();
            return Ok(_mapper.Map<QuotationResponseDto>(quotation));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuotationResponseDto>>> GetAll()
        {
            var quotations = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<QuotationResponseDto>>(quotations));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}

