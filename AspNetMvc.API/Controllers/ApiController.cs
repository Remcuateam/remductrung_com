using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc.API.Controllers
{
    [Authorize]
    [EnableCors("TeduCorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
    }
}