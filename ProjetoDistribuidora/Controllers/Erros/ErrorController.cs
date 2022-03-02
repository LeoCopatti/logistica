using Core.Shared.ModelViews;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProjetoDistribuidora.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var contexto = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Response.StatusCode = 500;

            var idErro = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;

            return new ErrorResponse(idErro);
        }
    }
}
