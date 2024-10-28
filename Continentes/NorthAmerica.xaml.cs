using Syncfusion.Maui.Maps;
using TrivialGeografia.Modelos;
using TrivialGeografia.ViewModel;

namespace TrivialGeografia;

public partial class NorthAmerica: ContentPage
{
    private string[] capitales;
    private string[] paises;
    private int aciertos = 0;
    private int fallos = 0;
    private int rondas = 0;
    private string capitalActual;
    private Random random = new Random();
    QuestViewModel QuestViewModel = new QuestViewModel();


    public NorthAmerica()
    {
        InitializeComponent();
        InicializarCapitales();
        crearColorMappings();
        modificarColor();
        BindingContext = QuestViewModel;
    }

    private void InicializarCapitales()
    {
        capitales = new string[]
{
            "Ottawa", "Washington D.C.", "Ciudad de México",
            "Guatemala City", "Belmopán", "Tegucigalpa",
            "San José", "Panamá City", "San Salvador",
            "Nassau", "Bridgetown", "Kingston","Nuuk","Managua","La Habana","Santo Domingo"
};

        paises = new string[]
        {
    "Canada", "United States", "Mexico",
    "Guatemala", "Belize", "Honduras",
    "Costa Rica", "Panama", "El Salvador",
    "Bahamas", "Barbados", "Jamaica","Greenland","Nicaragua","Cuba","Dominican Rep."
        };
    }

    private void MostrarSiguientePais(string Pais)
    {

        int index = Array.IndexOf(paises, Pais);
        capitalActual = capitales[index];
        List<string> opciones = ObtenerOpcionesConCapital(capitalActual);
        QuestViewModel.Pais = Pais;
        QuestViewModel.InicializarCiudades(opciones[0], opciones[1], opciones[2], opciones[3]);
        popup.BindingContext = QuestViewModel;
        popup.Show();

        rondas++;
    }

    private List<string> ObtenerOpcionesConCapital(string capital)
    {
        List<string> opciones = new List<string> { capital };

        while (opciones.Count < 4)
        {
            string ciudadAleatoria = capitales[random.Next(capitales.Length)];
            if (!opciones.Contains(ciudadAleatoria))
            {
                opciones.Add(ciudadAleatoria);
            }
        }
        return opciones.OrderBy(x => Guid.NewGuid()).ToList();
    }

    private void OnCiudadClicked(object sender, EventArgs e)
    {
        var boton = (Button)sender;

        if (boton.Text == capitalActual)
        {
            aciertos++;
            InfoContinenteAprobado.AciertosLista.Add(QuestViewModel.Pais);
        }
        else
        {
            fallos++;
            InfoContinenteAprobado.FallosLista.Add(QuestViewModel.Pais);
        }
        modificarColor();
        popup.Dismiss();
    }

    private void MostrarPais(object sender, ShapeSelectedEventArgs e)
    {
        if (e.IsSelected && e.DataItem is ModeloNorthAmerica selected)
        {
            MostrarSiguientePais(selected.Name);
        }
    }

    private void crearColorMappings()
    {
        Map.ColorMappings.Clear();
        foreach (var pais in paises)
        {
            var colorMapping = new EqualColorMapping
            {
                Value = pais,
                Color = Colors.LightGray
            };

            Map.ColorMappings.Add(colorMapping);
        }
    }

    private void modificarColor()
    {
        foreach (var pais in paises)
        {
            if (InfoContinenteAprobado.AciertosLista.Contains(pais))
            {
                CambiarColorAcierto(pais);
            }
            else if (InfoContinenteAprobado.FallosLista.Contains(pais))
            {
                CambiarColorFallo(pais);
            }
        }
    }

    private void CambiarColorAcierto(string pais)
    {
        var PaisColor = Map.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals(pais));
        if (PaisColor != null)
            PaisColor.Color = Colors.Green;
    }

    private void CambiarColorFallo(string pais)
    {
        var PaisColor = Map.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals(pais));
        if (PaisColor != null)
            PaisColor.Color = Colors.Red;
    }
}
