using ECommerce.Message.DTOs;
using ECommerce.Message.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IUserMessageService _userMessageService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _userMessageService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _userMessageService.GetByIdAsync(id);
            if (value is null)
            {
                return BadRequest("Message Not Found");
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserMessageDto messageDto)
        {
            await _userMessageService.CreateAsync(messageDto);
            return Ok("Message Created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserMessageDto messageDto)
        {
            await _userMessageService.UpdateAsync(id, messageDto);
            return Ok("Message Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userMessageService.DeleteAsync(id);
            return Ok("Message Deleted");
        }
    }
}
