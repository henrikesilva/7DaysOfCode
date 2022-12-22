using _7DaysOfCode.Servico;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _7DaysOfCode.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MascoteVirtualController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BuscarMascoteVirtual(string nome)
        {
            try
            {
                AnimalServico animalServico = new AnimalServico();
                var retorno = await animalServico.BuscarAnimal(nome);

                return Ok(retorno);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
