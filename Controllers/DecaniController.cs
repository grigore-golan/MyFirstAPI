using Microsoft.AspNetCore.Mvc;
using UniApi.Interfaces;
using UniApi.Models;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecaniController : Controller
    {
        private readonly IDecaniRepository _decani;
        public DecaniController(IDecaniRepository decani)
        {
            _decani = decani;
        }

        [HttpPost]
        public async Task<IActionResult> AddDecan(AddDecanRequest addRequest)
        {
            return Ok(await _decani.CreateDecanAsync(addRequest));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDecani()
        {
            return Ok(await _decani.GetAllDecaniAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDecan([FromRoute] Guid id)
        {
            return Ok(await _decani.GetDecanAsync(id));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDecan([FromRoute] Guid id, UpdateDecanRequest updateRequest)
        {
            return Ok(await _decani.UpdateDecanAsync(updateRequest, id));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDecan([FromRoute] Guid id)
        {
            return Ok(await _decani.DeleteDecanAsync(id));
        }
    }
}