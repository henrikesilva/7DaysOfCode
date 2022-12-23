using _7DaysOfCode.Servico;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static _7DaysOfCode.Enum.PokemonsDto;

namespace _7DaysOfCode.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MascoteVirtualController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MascoteVirtualController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarMascoteVirtual([FromQuery]NomesPokemon nome)
        {
            try
            {
                AnimalServico animalServico = new AnimalServico(_configuration);
                var retorno = await animalServico.BuscarAnimal(nome);

                if (retorno == null)
                    return NotFound("Não foram encontrados pokemon com esse nome");

                else return Ok(retorno); 
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
