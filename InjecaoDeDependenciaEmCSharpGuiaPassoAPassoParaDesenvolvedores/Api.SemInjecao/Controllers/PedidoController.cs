using Api.ComInjecao.Models;
using Api.ComInjecao.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.ComInjecao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController()
            => _pedidoService = new PedidoService();

        [HttpPost]
        public IActionResult Post(PedidoModel model)
        {
            try
            {
                return _pedidoService.SalvarNoBanco(model.Valor)
                    ? Ok() : NotFound();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}