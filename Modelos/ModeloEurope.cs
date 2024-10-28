namespace TrivialGeografia.Modelos
{
    public class ModeloEurope
    {
        public string Name { get; set; }
        public string Continent { get; set; }

        public ModeloEurope(string name, string continent)
        {
            Name = name;
            Continent = continent;
        }
    }

}
