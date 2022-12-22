namespace _7DaysOfCode.Model
{
    public class Abilities
    {
        public Ability ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }

    public class Ability
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}