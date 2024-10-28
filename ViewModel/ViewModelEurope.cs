using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using TrivialGeografia.Modelos;


namespace TrivialGeografia.ViewModel
{
    public class ViewModelEurope
    {
        public ObservableCollection<ModeloEurope> DataEurope { get; set; }

        public ViewModelEurope()
        {
            GenerateSource();
        }

        public void GenerateSource()
        {
            DataEurope = new ObservableCollection<ModeloEurope>();
            string url = "https://cdn.syncfusion.com/maps/map-data/europe.json";
            using (WebClient client = new WebClient())
            {
                try
                {
                    string getString = client.DownloadString(url);
                    Root GeoJson = JsonConvert.DeserializeObject<Root>(getString);
                    foreach (var item in GeoJson.features)
                    {
                        DataEurope.Add(new ModeloEurope(item.properties.name, item.properties.continent));
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
