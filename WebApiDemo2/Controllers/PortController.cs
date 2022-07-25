using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiDemo2.Data;
using WebApiDemo2.Models;
using WebApiDemo2.Repository;

namespace WebApiDemo2.Controllers
{
    [Route("api/Port")]
    [ApiController]
    public class PortController : ControllerBase
    {
        private readonly IPortRepository _PortRepository;
        //private object _IPortRepository;

        public PortController(IPortRepository PortRepository)
        {
            _PortRepository = PortRepository;
        }



        //[HttpGet("")]
        //public async Task<IActionResult> GetAllPortuser()
        //{
        //    var Portusers = await _PortRepository.GetAllPortusersAsync();
        //    return Ok(Portusers);
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPortuserByID([FromRoute] int id)
        //{
        //    var book = await _PortRepository.GetPortusersByIdAsync(id);
        //    return Ok(book);
        //}

        [HttpGet("")]
        public async Task<IActionResult> GetAllAvlSlots()
        {
            var slots = await _PortRepository.GetAvalSlotsAsync();
            return Ok(slots);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewPortuser([FromBody] Portuser PortuserClass)
        {
            //var books = await _bookRepository.AddBookAsync(bookClass);
            var id = await _PortRepository.AddPortusersAsync(PortuserClass);
            //return CreatedAtAction(nameof(GetPortuserByID), new { id = id, Controller = "Port" }, id);
            return Ok(id);

        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdatePortusers([FromBody] Portuser PortuserModel, [FromRoute] int id)
        //{
        //    await _PortRepository.UpdatePortusersAsync(id, PortuserModel);
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePortuser([FromRoute] int id)
        //{
        //    await _PortRepository.DeletePortusersAsync(id);
        //    return Ok();
        //}

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlot([FromBody] Portslot slotsModel, [FromRoute] int id)
        {
            await _PortRepository.UpdateSlot(id, slotsModel);
            return Ok();
        }

    }
}
