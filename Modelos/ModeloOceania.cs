namespace TrivialGeografia.Modelos
{
    public class ModeloOceania
    {
        public string Name { get; set; }
        public string Continent { get; set; }

        public ModeloOceania(string name, string continent)
        {
            Name = name;
            Continent = continent;
        }
    }
}
