using _7DaysOfCode.Conversors;
using _7DaysOfCode.Dto;
using _7DaysOfCode.Model;
using RestSharp;
using static _7DaysOfCode.Enum.PokemonsDto;

namespace _7DaysOfCode.Servico
{
    public class AnimalServico
    {
        private readonly IConfiguration _configuration;
        public AnimalServico(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PokemonDto> BuscarAnimal(NomesPokemon nomePokemon)
        {
            try
            {
                Pokemon pokemon = new Pokemon();
                PokemonDto pokemonDto = new PokemonDto();
                string apiUrl = _configuration.GetSection("Connections").GetSection("PokeApi").Value;

                RestResponse response = new RestResponse();

                var client = new RestClient($"{apiUrl}/{(int)nomePokemon}/");
                var request = new RestRequest();
                request.Method = Method.Get;
                response = await client.ExecuteAsync(request);

                if ((!string.IsNullOrEmpty(response.Content)) && response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    pokemon = System.Text.Json.JsonSerializer.Deserialize<Pokemon>(response.Content) ?? pokemon;
                    pokemonDto = PokemonMapper.ConvertToDto(pokemon);

                    return pokemonDto;
                }

                else return new PokemonDto();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocorreu um erro: ", ex.Message);
            }
        }
    }
}
