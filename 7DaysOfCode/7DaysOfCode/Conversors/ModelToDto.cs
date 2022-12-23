using _7DaysOfCode.Dto;
using _7DaysOfCode.Model;

namespace _7DaysOfCode.Conversors
{
    public static class HabilidadeMapper
    {
        public static HabilidadeDto ConvertToDto(this Ability ability)
        {
            return new HabilidadeDto { Nome = ability.name, Url = ability.url };
        }

        public static List<HabilidadeDto> ConvertToDto(this List<Ability> abilites)
        {
            return abilites.Select(a => a.ConvertToDto()).ToList();
        }
    }

    public static class HabilidadesMapper
    {
        public static HabilidadesDto ConvertToDto(this Abilities abilities)
        {
            return new HabilidadesDto { Habilidade = abilities.ability.ConvertToDto() };
        }

        public static List<HabilidadesDto> ConvertToDto(this List<Abilities> abilities)
        {
            return abilities.Select(h => h.ConvertToDto()).ToList();
        }
    }
    
    public static class PokemonMapper
    {
        public static PokemonDto ConvertToDto(this Pokemon pokemon)
        {
            return new PokemonDto { Nome = EnglishToPortuguese.ConvertEnglishToPortuguese(pokemon), Habilidades = pokemon.abilities.ConvertToDto()};
        }

        public static List<PokemonDto> ConvertToDto(this List<Pokemon> pokemons)
        {
            return pokemons.Select(a => a.ConvertToDto()).ToList();
        }
    }
}
