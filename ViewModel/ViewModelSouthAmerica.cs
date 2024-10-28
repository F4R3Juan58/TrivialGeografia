using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using TrivialGeografia.Modelos;


namespace TrivialGeografia.ViewModel
{
    public class ViewModelSouthAmerica
    {
        public ObservableCollection<ModeloSouthAmerica> DataSouthAmerica { get; set; }

        public ViewModelSouthAmerica()
        {
            GenerateSource();
        }

        public void GenerateSource()
        {
            DataSouthAmerica = new ObservableCollection<ModeloSouthAmerica>();
            string url = "https://cdn.syncfusion.com/maps/map-data/south-america.json";
            using (WebClient client = new WebClient())
            {
                try
                {
                    string getString = client.DownloadString(url);
                    Root GeoJson = JsonConvert.DeserializeObject<Root>(getString);
                    foreach (var item in GeoJson.features)
                    {
                        DataSouthAmerica.Add(new ModeloSouthAmerica(item.properties.name, item.properties.continent));
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
