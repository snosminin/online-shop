using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Server.Controllers;

public class DefaultController : BaseApiController
{
    [HttpGet]
    public IActionResult Get() => Ok("Hello!");
}