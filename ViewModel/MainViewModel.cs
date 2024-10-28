using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialGeografia.ViewModel
{
    public class MainViewModel
    {
        public ViewModelEurope Europe { get; set; }
        public ViewModelAsia Asia { get; set; }
        public ViewModelAfrica Africa { get; set; }
        public ViewModelOceania Oceania { get; set; }
        public ViewModelNorthAmerica NorthAmerica { get; set; }
        public ViewModelSouthAmerica SouthAmerica { get; set; }


        public MainViewModel()
        {
            Europe = new ViewModelEurope();
            Asia = new ViewModelAsia();
            Africa = new ViewModelAfrica();
            Oceania = new ViewModelOceania();
            NorthAmerica = new ViewModelNorthAmerica();
            SouthAmerica = new ViewModelSouthAmerica();
        }
    }
}
