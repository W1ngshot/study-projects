using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels;

namespace Producer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MessagesController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage(MessageDto messageDto)
    {
        await _publishEndpoint.Publish<MessageCreated>(new
        {
            Id = 1,
            messageDto.Text,
            messageDto.SomeNumber
        });

        return Ok();
    }
}