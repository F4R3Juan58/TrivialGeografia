using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using TrivialGeografia.Modelos;


namespace TrivialGeografia.ViewModel
{
    public class ViewModelWorld
    {
        public ObservableCollection<ModeloWorld> DataWorld { get; set; }

        public ViewModelWorld()
        {
            GenerateSource();
        }

        public void GenerateSource()
        {
            DataWorld = new ObservableCollection<ModeloWorld>();
            string url = "https://cdn.syncfusion.com/maps/map-data/world-map.json";
            using (WebClient client = new WebClient())
            {
                try
                {
                    string getString = client.DownloadString(url);
                    Root GeoJson = JsonConvert.DeserializeObject<Root>(getString);
                    foreach (var item in GeoJson.features)
                    {
                        DataWorld.Add(new ModeloWorld(item.properties.name, item.properties.continent));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error recibiendo el json: {ex.Message}");
                }
            }
        }
    }
}
