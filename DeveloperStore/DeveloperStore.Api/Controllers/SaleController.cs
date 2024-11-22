using DeveloperStore.Application.Interface;
using DeveloperStore.Application.Services;
using DeveloperStore.Domain.Entity;
using DeveloperStore.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.Api.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SaleController : Controller
    {
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListAllSalesAsync([FromServices] ISaleService saleService)
        {
            try
            {
                var result = await saleService.ListAll();
                if (result.Valid)
                {
                    var model = result.Data as IEnumerable<Sale>;
                    return Ok(model);
                }
                else
                {
                    LogSentry.EnviarMsgSentry(result.Message);
                    return BadRequest($"Ocorreu um erro, Detalhe: {result.Message}.");
                }
            }
            catch (Exception ex)
            {
                LogSentry.EnviarExceptionSentry(ex);
                return StatusCode(500, new { Message = "An error occurred while list the sale.", Details = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromServices] ISaleService saleService, int id)
        {
            try
            {
                var result = await saleService.GetById(id);
                if (result.Valid)
                {
                    var model = result.Data as IEnumerable<Sale>;
                    return Ok(model);
                }
                else
                {
                    LogSentry.EnviarMsgSentry(result.Message);
                    return BadRequest($"Ocorreu um erro, Detalhe: {result.Message}.");
                }
            }
            catch (Exception ex)
            {
                LogSentry.EnviarExceptionSentry(ex);
                return StatusCode(500, new { Message = "An error occurred while get the sale.", Details = ex.Message });
            }
        }

        [HttpPost]
        [Route("Insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromServices] ISaleService saleService, [FromBody] Sale model)
        {
            try
            {
                var result = await saleService.Insert(model);
                if (result.Valid)
                {
                    return Created("Salvo com sucesso.", model);
                }
                else
                {
                    LogSentry.EnviarMsgSentry(result.Message);
                    return BadRequest($"Erro ao salvar detalhes: {result.Message}");
                }
            }
            catch (Exception ex)
            {
                LogSentry.EnviarExceptionSentry(ex);
                return StatusCode(500, new { Message = "An error occurred while insert the sale.", Details = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromServices] ISaleService saleService, [FromBody] Sale model)
        {
            try
            {
                var result = await saleService.Update(model);
                if (result.Valid)
                {
                    return Created("Salvo com sucesso.", model);
                }
                else
                {
                    LogSentry.EnviarMsgSentry(result.Message);
                    return BadRequest($"Erro ao atualizar detalhes: {result.Message}");
                }
            }
            catch (Exception ex)
            {
                LogSentry.EnviarExceptionSentry(ex);
                return StatusCode(500, new { Message = "An error occurred while update the sale.", Details = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteSale/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSale([FromServices] ISaleService saleService, int id)
        {
            try
            {
                // Verifica se a venda existe
                var result = await saleService.GetById(id);
                var sale = result.Data as IEnumerable<Sale>;
                if (sale == null)
                {
                    // Retorna 404 Not Found se a venda não existir
                    return NotFound(new { Message = $"Sale with ID {id} not found." });
                }

                // Chama o serviço para excluir a venda
                result = await saleService.Delete(id);

                // Retorna 204 No Content para indicar sucesso na exclusão
                if (result.Valid)
                    return NoContent();
                else
                {
                    LogSentry.EnviarMsgSentry(result.Message);
                    return BadRequest($"Erro ao atualizar detalhes: {result.Message}");
                }
            }
            catch (Exception ex)
            {
                LogSentry.EnviarExceptionSentry(ex);
                return StatusCode(500, new { Message = "An error occurred while deleting the sale.", Details = ex.Message });
            }
        }
    }
}
