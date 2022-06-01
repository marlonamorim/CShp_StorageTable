using MGM.MVP.StorageTable.Entities;
using MGM.MVP.StorageTable.Services;
using MGM.MVP.StorageTable.WebApi.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;

        public PedidosController(ILogger<PedidosController> logger)
            => _logger = logger;

        [HttpGet("")]
        [SwaggerOperation(Summary = "Retorna Pedidos por execução de planos")]
        [ProducesResponseType(typeof(IEnumerable<Entity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromServices] IPedidoTableService pedidoTableService,
            [FromQuery] FilterResultsInputModel inputModel)
                => Ok(pedidoTableService.GetAllRows(inputModel.ApplyFilter()));

        [HttpPost("/criar")]
        [SwaggerOperation(Summary = "Cadastra Pedido por execução de plano")]
        [ProducesResponseType(typeof(IEnumerable<Entity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Post([FromServices] IPedidoTableService pedidoTableService,
            [FromBody] Pedido pedido)
                => pedidoTableService.InsertPedido(pedido);

        [HttpPut("/atualizar")]
        [SwaggerOperation(Summary = "Atualiza Pedido por execução de plano")]
        [ProducesResponseType(typeof(IEnumerable<Entity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Put([FromServices] IPedidoTableService pedidoTableService,
            [FromBody] Pedido pedido)
                => pedidoTableService.UpdatePedido(pedido);

        [HttpDelete("/deletar/{partitionKey}/{rowKey}")]
        [SwaggerOperation(Summary = "Deleta Pedido por Chave de Partição e Chave de Linha")]
        [ProducesResponseType(typeof(IEnumerable<Entity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete([FromServices] IPedidoTableService pedidoTableService,
            [FromRoute][NotNull] string partitionKey, [FromRoute][NotNull] string rowKey)
                => pedidoTableService.DeleteTableEntity(partitionKey, rowKey);
    }
}
