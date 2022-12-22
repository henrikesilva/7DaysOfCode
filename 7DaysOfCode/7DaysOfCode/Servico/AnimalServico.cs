using _7DaysOfCode.Model;
using RestSharp;
using System.Text.Json;

namespace _7DaysOfCode.Servico
{
    public class AnimalServico
    {
        public async Task<List<Pokemon>> BuscarAnimal(string nomePokemon)
        {
            try
            {
                List<Pokemon> pokemons = new List<Pokemon>();

                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{nomePokemon}/");
                var request = new RestRequest();
                request.Method = Method.Get;
                RestResponse response = await client.ExecuteAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resultado = System.Text.Json.JsonSerializer.Deserialize<Pokemon>(response.Content);
                    pokemons.Add(resultado);
                    return pokemons;
                }

                throw new ArgumentException("Erro ao buscar os dados!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
