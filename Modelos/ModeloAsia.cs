namespace TrivialGeografia.Modelos
{
    public class ModeloAsia
    {
        public string Name { get; set; }
        public string Continent { get; set; }

        public ModeloAsia(string name, string continent)
        {
            Name = name;
            Continent = continent;
        }
    }
}
