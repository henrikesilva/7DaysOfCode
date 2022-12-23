using _7DaysOfCode.Model;
using static _7DaysOfCode.Enum.PokemonsDto;

namespace _7DaysOfCode.Conversors
{
    public class EnglishToPortuguese
    {
        public static string ConvertEnglishToPortuguese(Pokemon objeto)
        {
            string nome = "";

            switch (objeto.name)
            {
                case "bulbasaur":
                    nome = NomesPokemon.bulbasauro.ToString();
                    break;
            }

            return nome;
        }
    }
}
