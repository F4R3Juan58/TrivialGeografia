using Syncfusion.Maui.Maps;
using TrivialGeografia.Modelos;
using TrivialGeografia.ViewModel;

namespace TrivialGeografia;

public partial class SouthAmerica : ContentPage
{
    private string[] capitales;
    private string[] paises;
    private int aciertos = 0;
    private int fallos = 0;
    private int rondas = 0;
    private string capitalActual;
    private Random random = new Random();
    QuestViewModel QuestViewModel = new QuestViewModel();

    public SouthAmerica()
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
            "Buenos Aires", "Brasilia", "Santiago", "Bogotá", "Lima",
            "Montevideo", "Caracas", "La Paz", "Quito", "Asunción","Puerto Argentino",
            "Georgetown","Paramaribo"
        };

        paises = new string[]
        {
    "Argentina", "Brazil", "Chile", "Colombia", "Peru",
    "Uruguay", "Venezuela", "Bolivia", "Ecuador", "Paraguay","Falkland Is.",
    "Guyana","Suriname"
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

        // Baraja las opciones
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
        if (e.IsSelected && e.DataItem is ModeloSouthAmerica selected)
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

