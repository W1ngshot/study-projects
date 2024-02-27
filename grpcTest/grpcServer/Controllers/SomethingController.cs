using Microsoft.AspNetCore.Mvc;

namespace grpcServer.Controllers;

[ApiController]
[Route("[controller]")]
public class SomethingController : ControllerBase
{
    [HttpGet(Name = "GetSomething")]
    public int Get()
    {
        return 1;
    }
}