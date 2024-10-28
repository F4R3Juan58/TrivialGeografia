using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using TrivialGeografia.Modelos;


namespace TrivialGeografia.ViewModel
{
    public class ViewModelOceania
    {
        public ObservableCollection<ModeloOceania> DataOceania { get; set; }

        public ViewModelOceania()
        {
            GenerateSource();
        }

        public void GenerateSource()
        {
            DataOceania = new ObservableCollection<ModeloOceania>();
            string url = "https://cdn.syncfusion.com/maps/map-data/oceania.json";
            using (WebClient client = new WebClient())
            {
                try
                {
                    string getString = client.DownloadString(url);
                    Root GeoJson = JsonConvert.DeserializeObject<Root>(getString);
                    foreach (var item in GeoJson.features)
                    {
                        DataOceania.Add(new ModeloOceania(item.properties.name, item.properties.continent));
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
