using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STS.Application.ViewModels;
using STS.Domain.Entities;
using STS.Infrastructure.Security;
using System.Threading.Tasks;

namespace STS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        [HttpPost]
        [Route("token")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<ActionResult> Token([FromForm] UsuarioViewModel usuario)
        {
            //capturar isso do banco... usar asp net identity! ...
            var user = new Usuario  { Nome = "teste", Grupo = "G_EMAIL_GUEST" };

            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            return Ok(TokenGenerator.GenerateToken(user));
        }

        [Authorize]
        [HttpPost]
        [Route("validate")]
        public async Task<ActionResult> Validate()
        {
            return Ok();
        }
    }
}
