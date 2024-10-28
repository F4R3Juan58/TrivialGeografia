namespace TrivialGeografia.Modelos
{
    public class ModeloNorthAmerica
    {
        public string Name { get; set; }
        public string Continent { get; set; }

        public ModeloNorthAmerica(string name, string continent)
        {
            Name = name;
            Continent = continent;
        }
    }

}
