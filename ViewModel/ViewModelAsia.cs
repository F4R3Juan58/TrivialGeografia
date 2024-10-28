using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using TrivialGeografia.Modelos;


namespace TrivialGeografia.ViewModel
{
    public class ViewModelAsia
    {
        public ObservableCollection<ModeloAsia> DataAsia { get; set; }

        public ViewModelAsia()
        {
            GenerateSource();
        }

        public void GenerateSource()
        {
            DataAsia = new ObservableCollection<ModeloAsia>();
            string url = "https://cdn.syncfusion.com/maps/map-data/asia.json";
            using (WebClient client = new WebClient())
            {
                try
                {
                    string getString = client.DownloadString(url);
                    Root GeoJson = JsonConvert.DeserializeObject<Root>(getString);
                    foreach (var item in GeoJson.features)
                    {
                        DataAsia.Add(new ModeloAsia(item.properties.name, item.properties.continent));
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
