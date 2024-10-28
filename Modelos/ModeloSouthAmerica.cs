namespace TrivialGeografia.Modelos
{
    public class ModeloSouthAmerica
    {
        public string Name { get; set; }
        public string Continent { get; set; }

        public ModeloSouthAmerica(string name, string continent)
        {
            Name = name;
            Continent = continent;
        }
    }

}
