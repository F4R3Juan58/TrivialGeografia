using Syncfusion.Maui.Maps;
using TrivialGeografia.Modelos;
using TrivialGeografia.ViewModel;

namespace TrivialGeografia;

public partial class Asia : ContentPage
{
    private string[] capitales;
    private string[] paises;
    private int aciertos = 0;
    private int fallos = 0;
    private int rondas = 0;
    private string capitalActual;
    private Random random = new Random();
    QuestViewModel QuestViewModel = new QuestViewModel();


    public Asia()
    {
        InitializeComponent();
        InicializarCapitales();
        crearColorMappings();
        modificarColor();
        BindingContext = QuestViewModel;
    }

    private void InicializarCapitales()
    {
        capitales = new string[] {
    "Tokio", "Pekín", "Nueva Delhi", "Seúl", "Bangkok", "Kuala Lumpur",
    "Hanoi", "Yakarta", "Manila", "Singapur", "Riad", "Doha", "Abu Dabi", "Teherán",
    "Damasco", "Ammán", "Kabul", "Nicosia", "Ereván", "Bakú", "Tiflis", "Taipéi",
    "Ulan Bator", "Katmandú", "Astaná", "Bishkek", "Dusambé", "Ashgabat", "Bagdad", "Jerusalén",
    "Beirut", "Saná", "Malé", "Sri Jayawardenepura Kotte","Moscú","Ankara","Mascate","Kuwait"
    ,"Islamabad","Daca","Timbu","Naipyidó","Vientián","Nom Pen","Pionyang","Taskent","Dili"
};

        paises = new string[] {
    "Japan", "China", "India", "Dem. Rep. Korea", "Thailand", "Malaysia",
    "Vietnam", "Indonesia", "Philippines", "Singapore", "Saudi Arabia", "Qatar",
    "United Arab Emirates", "Iran", "Syria", "Jordan", "Afghanistan", "Cyprus",
    "Armenia", "Azerbaijan", "Georgia", "Taiwan", "Mongolia", "Nepal", "Kazakhstan",
    "Kyrgyzstan", "Tajikistan", "Turkmenistan", "Iraq", "Israel", "Lebanon",
    "Yemen", "Maldives", "Sri Lanka","Russia","Turkey","Oman","Kuwait","Pakistan","Bangladesh",
    "Bhutan","Myanmar","Lao PDR","Cambodia","Korea","Uzbekistan","Timor-Leste"
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

        // Agrega 3 ciudades incorrectas aleatorias
        while (opciones.Count < 4)
        {
            string ciudadAleatoria = capitales[random.Next(capitales.Length)];
            if (!opciones.Contains(ciudadAleatoria)) // Evitar duplicados
            {
                opciones.Add(ciudadAleatoria);
            }
        }

        // Baraja las opciones
        return opciones.OrderBy(x => Guid.NewGuid()).ToList();
    }

    private async void MostrarResultados()
    {
        bool respuesta = await DisplayAlert("Resultados", $"Aciertos: {aciertos}, Fallos: {fallos}", "Continuar", "Volver al continente");

        if (respuesta)
        {
            await Navigation.PushAsync(new Asia());
        }
        else
        {
            await Navigation.PushAsync(new Asia());
        }
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
        if (e.IsSelected && e.DataItem is ModeloAsia selected)
        {
            MostrarSiguientePais(selected.Name);

        }
    }

    private void crearColorMappings()
    {
        MapAsia.ColorMappings.Clear();
        foreach (var pais in paises)
        {
            var colorMapping = new EqualColorMapping
            {
                Value = pais,
                Color = Colors.LightGray
            };
            MapAsia.ColorMappings.Add(colorMapping);
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
        var PaisColor = MapAsia.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals(pais));
        if (PaisColor != null)
            PaisColor.Color = Colors.Green;
    }

    private void CambiarColorFallo(string pais)
    {
        var PaisColor = MapAsia.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals(pais));
        if (PaisColor != null)
            PaisColor.Color = Colors.Red;
    }

}