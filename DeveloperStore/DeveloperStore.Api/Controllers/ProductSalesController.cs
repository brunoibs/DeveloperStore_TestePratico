
using DeveloperStore.Application.Interface;
using DeveloperStore.Application.Services;
using DeveloperStore.Domain.Entity;
using DeveloperStore.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.Api.Controllers
{
    [Route("api/Product_Saless")]
    [ApiController]
    public class ProductSalesController : Controller
    {
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListAllProduct_SalessAsync([FromServices] IProduct_SalesService Product_SalesService)
        {
            try
            {
                var result = await Product_SalesService.ListAll();
                if (result.Valid)
                {
                    var model = result.Data as IEnumerable<Product_Sale>;
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
                return StatusCode(500, new { Message = "An error occurred while list the Product_Sales.", Details = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromServices] IProduct_SalesService Product_SalesService, int id)
        {
            try
            {
                var result = await Product_SalesService.GetById(id);
                if (result.Valid)
                {
                    var model = result.Data as IEnumerable<Product_Sale>;
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
                return StatusCode(500, new { Message = "An error occurred while get the Product_Sales.", Details = ex.Message });
            }
        }

        [HttpPost]
        [Route("Insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromServices] IProduct_SalesService Product_SalesService, [FromBody] Product_Sale model)
        {
            try
            {
                var result = await Product_SalesService.Insert(model);
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
                return StatusCode(500, new { Message = "An error occurred while insert the Product_Sales.", Details = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromServices] IProduct_SalesService Product_SalesService, [FromBody] Product_Sale model)
        {
            try
            {
                var result = await Product_SalesService.Update(model);
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
                return StatusCode(500, new { Message = "An error occurred while update the Product_Sales.", Details = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteProduct_Sales/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct_Sales([FromServices] IProduct_SalesService Product_SalesService, int id)
        {
            try
            {
                // Verifica se a venda existe
                var result = await Product_SalesService.GetById(id);
                var Product_Sales = result.Data as IEnumerable<Product_Sale>;
                if (Product_Sales == null)
                {
                    // Retorna 404 Not Found se a venda não existir
                    return NotFound(new { Message = $"Product_Sales with ID {id} not found." });
                }

                // Chama o serviço para excluir a venda
                result = await Product_SalesService.Delete(id);

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
                return StatusCode(500, new { Message = "An error occurred while deleting the Product_Sales.", Details = ex.Message });
            }
        }
    }
}





