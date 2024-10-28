using Syncfusion.Maui.Maps;
using TrivialGeografia.Modelos;
using TrivialGeografia.ViewModel;

namespace TrivialGeografia;

public partial class Africa : ContentPage
{
    private string[] capitales;
    private string[] paises;
    private int aciertos = 0;
    private int fallos = 0;
    private int rondas = 0;
    private string capitalActual;
    private Random random = new Random();
    QuestViewModel QuestViewModel = new QuestViewModel();

    public Africa()
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
    "Abuya", "El Cairo", "Pretoria", "Nairobi", "Adís Abeba", "Dakar", "Luanda", "Rabat", "Túnez", "Jartum",
    "Kampala", "Maputo", "Gaborone", "Uagadugú", "Buyumbura", "Yaundé", "Bangui", "Yamena", "Moroni", "Kinshasa",
    "Yibuti", "Malabo", "Asmara", "Mbabane", "Libreville", "Banjul", "Acra", "Conakri", "Bisáu", "Abiyán",
    "Maseru", "Monrovia", "Trípoli", "Antananarivo", "Lilongüe", "Bamako", "Nuakchot", "Port Louis", "Rabat",
    "Maputo", "Windhoek", "Niamey", "Abuya", "Santo Tomé", "Dakar", "Victoria", "Freetown", "Mogadiscio",
    "Yuba", "Cartago", "Dodoma", "Lomé", "Túnez", "Kampala", "Lusaka", "Harare","Argel","El Aaiun","Yamusukro","Malabo","Brazzaville","Kinsasa",
    "Bangui","Porto Novo","Lobamba","Kigali","Yuba","Mogadiscio"
};

        paises = new string[] {
    "Nigeria", "Egypt", "South Africa", "Kenya", "Ethiopia", "Senegal", "Angola", "Morocco", "Tunisia", "Sudan",
    "Uganda", "Mozambique", "Botswana", "Burkina Faso", "Burundi", "Cameroon", "Central African Republic", "Chad",
    "Comoros", "Democratic Republic of the Congo", "Djibouti", "Equatorial Guinea", "Eritrea", "Eswatini", "Gabon",
    "Gambia", "Ghana", "Guinea", "Guinea-Bissau", "Ivory Coast", "Lesotho", "Liberia", "Libya", "Madagascar", "Malawi",
    "Mali", "Mauritania", "Mauritius", "Morocco", "Mozambique", "Namibia", "Niger", "Nigeria", "Sao Tome and Principe",
    "Senegal", "Seychelles", "Sierra Leone", "Somalia", "South Sudan", "Sudan", "Tanzania", "Togo", "Tunisia",
    "Uganda", "Zambia", "Zimbabwe","Algeria","W. Sahara","Côte d'Ivoire","Eq. Guinea","Congo","Dem. Rep. Congo",
    "Central African Rep.","Benin","Swaziland","Rwanda","S. Sudan","Somaliland"
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
        if (e.IsSelected && e.DataItem is ModeloAfrica selected)
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

            // Agrega el colorMapping al mapa
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
        PaisColor.Color = Colors.Green;
    }

    private void CambiarColorFallo(string pais)
    {
        var continenteColor = Map.ColorMappings.OfType<EqualColorMapping>().FirstOrDefault(c => c.Value.Equals(pais));
        continenteColor.Color = Colors.Red;
    }

}

