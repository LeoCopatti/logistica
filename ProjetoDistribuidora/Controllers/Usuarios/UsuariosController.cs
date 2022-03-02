using Core.Domain.User;
using Core.Shared.ModelViews;
using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjetoDistribuidora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioManager _usuarioManager;

        public UsuariosController(IUsuarioManager usuarioManager)
        {
            _usuarioManager = usuarioManager;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] Usuario usuario)
        {
            var usuarioLogado = await _usuarioManager.ValidaUsuarioEGeraTokenAsync(usuario);

            if (usuarioLogado != null)
                return Ok(usuarioLogado);

            return Unauthorized();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var login = User.Identity.Name;
            return Ok(await _usuarioManager.GetUsuarioAsync(login));
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovoUsuario novoUsuario)
        {
            var usuarioInserido = await _usuarioManager.InsertUsuarioAsync(novoUsuario);
            return CreatedAtAction(nameof(Get), new { login = usuarioInserido.Login }, usuarioInserido);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Usuario usuario)
        {
            var usuarioAtualizado = await _usuarioManager.UpdateUsuarioAsync(usuario);
            if (usuarioAtualizado == null)
                return NotFound();

            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{login}")]
        public async Task<IActionResult> Delete(string login)
        {
            await _usuarioManager.DeleteUsuarioAsync(login);
            return NoContent();
        }

    }
}
