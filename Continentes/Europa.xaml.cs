using Syncfusion.Maui.Maps;
using TrivialGeografia.Modelos;
using TrivialGeografia.ViewModel;

namespace TrivialGeografia;

public partial class Europa : ContentPage
{
    private string[] capitales;
    private string[] paises;
    private int aciertos = 0;
    private int fallos = 0;
    private int rondas = 0;
    private string capitalActual;
    private Random random = new Random();
    QuestViewModel QuestViewModel = new QuestViewModel();

    public Europa()
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
    "Berlín", "Viena", "Bruselas", "Sofía", "Nicosia", "Zagreb", "Copenhague",
    "Bratislava", "Liubliana", "Madrid", "Tallin", "Helsinki", "París", "Atenas",
    "Budapest", "Dublín", "Roma", "Riga", "Vilna", "Luxemburgo", "La Valeta",
    "Ámsterdam", "Varsovia", "Lisboa", "Londres", "Praga", "Bucarest",
    "Estocolmo", "Reikiavik", "Oslo", "Chisináu", "Minsk", "Kiev", "Belgrado",
    "Sarajevo", "Skopje", "Podgorica", "Pristina", "Tiflis", "Ereván", "Bakú", "Berna","Tirana"
};

        paises = new string[]
        {
    "Germany", "Austria", "Belgium", "Bulgaria", "Cyprus", "Croatia", "Denmark",
    "Slovakia", "Slovenia", "Spain", "Estonia", "Finland", "France", "Greece",
    "Hungary", "Ireland", "Italy", "Latvia", "Lithuania", "Luxembourg", "Malta",
    "Netherlands", "Poland", "Portugal", "United Kingdom", "Czech Rep.", "Romania",
    "Sweden", "Iceland", "Norway", "Moldova", "Belarus", "Ukraine", "Serbia",
    "Bosnia and Herz.", "Macedonia", "Montenegro", "Kosovo", "Georgia",
    "Armenia", "Azerbaijan","Switzerland","Albania"
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
        if (e.IsSelected && e.DataItem is ModeloEurope selected)
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
