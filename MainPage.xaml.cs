using Syncfusion.Maui.Maps;
using Syncfusion.Maui.ProgressBar;
using TrivialGeografia.Modelos;

namespace TrivialGeografia
{
    public partial class MainPage : ContentPage
    {
        int aprobados = InfoContinenteAprobado.aprobados;
        public MainPage()
        {
            InitializeComponent();
            cambiarColor();
            aumentarProgreso();
        }


        private void OnShapeSelected(object sender, Syncfusion.Maui.Maps.ShapeSelectedEventArgs e)
        {
            if (e.IsSelected && e.DataItem is ModeloWorld selectedItem)
            {
                quest(selectedItem.Continent);
            }
        }

        private async void quest(string continente)
        {
            if (continente == "Europe" && !InfoContinenteAprobado.Europa) await Navigation.PushAsync(new Europa());
            if (continente == "Asia" && !InfoContinenteAprobado.Asia) await Navigation.PushAsync(new Asia());
            if (continente == "North America" && !InfoContinenteAprobado.NorthAmerica) await Navigation.PushAsync(new NorthAmerica());
            if (continente == "South America" && !InfoContinenteAprobado.SouthAmerica) await Navigation.PushAsync(new SouthAmerica());
            if (continente == "Australia" && !InfoContinenteAprobado.Oceania) await Navigation.PushAsync(new Oceania());
            if (continente == "Africa" && !InfoContinenteAprobado.Africa) await Navigation.PushAsync(new Africa());
        }

        public void aumentarProgreso()
        {
            int aprobados = 0;
            if (InfoContinenteAprobado.Europa) aprobados++;
            if (InfoContinenteAprobado.Asia) aprobados++;
            if (InfoContinenteAprobado.NorthAmerica) aprobados++;
            if (InfoContinenteAprobado.SouthAmerica) aprobados++;
            if (InfoContinenteAprobado.Oceania) aprobados++;
            if (InfoContinenteAprobado.Africa) aprobados++;

            int porcion = 10;
            Progreso.Progress = porcion * aprobados;
        }
        public void cambiarColor()
        {
            string[] continentesAprobados = new string[6];

            if (InfoContinenteAprobado.Europa)
            {
                var continenteColor = Map.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals("Europe"));
                if (continenteColor!= null) continenteColor.Color = Color.FromArgb("#747474 ");

            }
            if (InfoContinenteAprobado.Asia)
            {
                var continenteColor = Map.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals("Asia"));
                if (continenteColor != null) continenteColor.Color = Color.FromArgb("#747474 ");
            }
            if (InfoContinenteAprobado.NorthAmerica)
            {
                var continenteColor = Map.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals("North America"));
                if (continenteColor != null)  continenteColor.Color = Color.FromArgb("#747474 ");
            }
            if (InfoContinenteAprobado.SouthAmerica)
            {
                var continenteColor = Map.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals("South America"));
                if (continenteColor != null)  continenteColor.Color = Color.FromArgb("#747474 ");
            }
            if (InfoContinenteAprobado.Oceania)
            {
                var continenteColor = Map.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals("Australia"));
                if (continenteColor != null)  continenteColor.Color = Color.FromArgb("#747474 ");
            }
            if (InfoContinenteAprobado.Africa)
            {
                var continenteColor = Map.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals("Africa"));
                if (continenteColor != null)  continenteColor.Color = Color.FromArgb("#747474 ");
            }
        }

        private void onReiniciar(object sender, EventArgs e)
        {
            InfoContinenteAprobado.AciertosLista.Clear();
            InfoContinenteAprobado.FallosLista.Clear();
        }
    }
}





