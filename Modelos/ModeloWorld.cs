namespace TrivialGeografia.Modelos
{
    public class ModeloWorld
    {
        public string Name { get; set; }
        public string Continent { get; set; }

        public ModeloWorld(string name, string continent)
        {
            Name = name;
            Continent = continent;
        }
    }

    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<object>>> coordinates { get; set; }
    }

    public class Properties
    {
        public string name { get; set; }
        public string admin { get; set; }
        public string continent { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public Crs crs { get; set; }
        public List<Feature> features { get; set; }
    }


}
