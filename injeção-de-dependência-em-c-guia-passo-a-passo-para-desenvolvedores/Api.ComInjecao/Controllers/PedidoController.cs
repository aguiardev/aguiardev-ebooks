using Api.ComInjecao.Models;
using Api.ComInjecao.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ComInjecao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
            => _pedidoService = pedidoService;

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