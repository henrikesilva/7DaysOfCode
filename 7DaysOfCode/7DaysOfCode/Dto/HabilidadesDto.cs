using _7DaysOfCode.Model;

namespace _7DaysOfCode.Dto
{
    public class HabilidadesDto
    {
        public HabilidadeDto Habilidade { get; set; }
    }

    public class HabilidadeDto
    {
        public string Nome { get; set; }
        public string Url { get; set; }
    }
}
