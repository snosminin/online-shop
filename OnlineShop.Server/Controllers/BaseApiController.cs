using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Server.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class BaseApiController : ControllerBase;