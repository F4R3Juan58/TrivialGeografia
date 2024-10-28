using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using TrivialGeografia.Modelos;


namespace TrivialGeografia.ViewModel
{
    public class ViewModelNorthAmerica
    {
        public ObservableCollection<ModeloNorthAmerica> DataNorthAmerica { get; set; }

        public ViewModelNorthAmerica()
        {
            GenerateSource();
        }

        public void GenerateSource()
        {
            DataNorthAmerica = new ObservableCollection<ModeloNorthAmerica>();
            string url = "https://cdn.syncfusion.com/maps/map-data/north-america.json";
            using (WebClient client = new WebClient())
            {
                try
                {
                    string getString = client.DownloadString(url);
                    Root GeoJson = JsonConvert.DeserializeObject<Root>(getString);
                    foreach (var item in GeoJson.features)
                    {
                        DataNorthAmerica.Add(new ModeloNorthAmerica(item.properties.name, item.properties.continent));
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
