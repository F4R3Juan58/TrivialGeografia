using System;
using System.Collections.Generic;

namespace TrivialGeografia
{
    internal class InfoContinenteAprobado
    {
        public static bool Europa { get; set; }
        public static bool Asia { get; set; }
        public static bool NorthAmerica { get; set; }
        public static bool SouthAmerica { get; set; }
        public static bool Oceania { get; set; }
        public static bool Africa { get; set; }
        public static int aprobados { get; set; }

        public static List<string> AciertosLista { get; } = new List<string>();
        public static List<string> FallosLista { get; } = new List<string>();

        public InfoContinenteAprobado()
        {
            Europa = false;
            Asia = false;
            NorthAmerica = false;
            SouthAmerica = false;
            Oceania = false;
            Africa = false;
        }
    }
}
