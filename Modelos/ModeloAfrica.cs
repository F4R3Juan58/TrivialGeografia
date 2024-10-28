namespace TrivialGeografia.Modelos
{
    public class ModeloAfrica
    {
        public string Name { get; set; }
        public string Continent { get; set; }

        public ModeloAfrica(string name, string continent)
        {
            Name = name;
            Continent = continent;
        }
    }
}
