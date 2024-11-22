
using DeveloperStore.Application.Interface;
using DeveloperStore.Application.Services;
using DeveloperStore.Domain.Entity;
using DeveloperStore.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.Api.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListAllProductsAsync([FromServices] IProductService ProductService)
        {
            try
            {
                var result = await ProductService.ListAll();
                if (result.Valid)
                {
                    var model = result.Data as IEnumerable<Product>;
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
                return StatusCode(500, new { Message = "An error occurred while list the Product.", Details = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromServices] IProductService ProductService, int id)
        {
            try
            {
                var result = await ProductService.GetById(id);
                if (result.Valid)
                {
                    var model = result.Data as IEnumerable<Product>;
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
                return StatusCode(500, new { Message = "An error occurred while get the Product.", Details = ex.Message });
            }
        }

        [HttpPost]
        [Route("Insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromServices] IProductService ProductService, [FromBody] Product model)
        {
            try
            {
                var result = await ProductService.Insert(model);
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
                return StatusCode(500, new { Message = "An error occurred while insert the Product.", Details = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromServices] IProductService ProductService, [FromBody] Product model)
        {
            try
            {
                var result = await ProductService.Update(model);
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
                return StatusCode(500, new { Message = "An error occurred while update the Product.", Details = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct([FromServices] IProductService ProductService, int id)
        {
            try
            {
                // Verifica se a venda existe
                var result = await ProductService.GetById(id);
                var Product = result.Data as IEnumerable<Product>;
                if (Product == null)
                {
                    // Retorna 404 Not Found se a venda não existir
                    return NotFound(new { Message = $"Product with ID {id} not found." });
                }

                // Chama o serviço para excluir a venda
                result = await ProductService.Delete(id);

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
                return StatusCode(500, new { Message = "An error occurred while deleting the Product.", Details = ex.Message });
            }
        }
    }
}





