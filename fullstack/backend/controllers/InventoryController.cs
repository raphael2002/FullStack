using Microsoft.AspNetCore.Mvc;
using InventoryHub.Api.Models;
using InventoryHub.Api.Services;

namespace InventoryHub.Api.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _service;

        public InventoryController(InventoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var items = _service.GetAll(page, pageSize);
            return Ok(new
            {
                page,
                pageSize,
                count = items.Count(),
                data = items
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _service.Get(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] InventoryItemDto item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _service.Create(item);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] InventoryItemDto item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _service.Update(id, item);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
