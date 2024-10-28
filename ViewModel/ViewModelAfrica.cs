using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using TrivialGeografia.Modelos;


namespace TrivialGeografia.ViewModel
{
    public class ViewModelAfrica
    {
        public ObservableCollection<ModeloAfrica> DataAfrica { get; set; }

        public ViewModelAfrica()
        {
            GenerateSource();
        }

        public void GenerateSource()
        {
            DataAfrica = new ObservableCollection<ModeloAfrica>();
            string url = "https://cdn.syncfusion.com/maps/map-data/africa.json";
            using (WebClient client = new WebClient())
            {
                try
                {
                    string getString = client.DownloadString(url);
                    Root GeoJson = JsonConvert.DeserializeObject<Root>(getString);
                    foreach (var item in GeoJson.features)
                    {
                        DataAfrica.Add(new ModeloAfrica(item.properties.name, item.properties.continent));
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
