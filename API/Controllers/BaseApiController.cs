using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // https://localhost:5001/api/users
    public class BaseApiController : ControllerBase
    {
    }
};
