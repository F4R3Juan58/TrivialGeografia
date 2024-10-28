using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TrivialGeografia.ViewModel
{
    internal class QuestViewModel : INotifyPropertyChanged
    {
        private string pais, ciudad1, ciudad2, ciudad3, ciudad4;

        public string Pais
        {
            get { return pais; }
            set
            {
                pais = value;
                OnPropertyChanged(nameof(Pais));
                OnPropertyChanged(nameof(LabelString)); // Actualiza LabelString si el país cambia
            }
        }

        public string Ciudad1
        {
            get { return ciudad1; }
            set
            {
                ciudad1 = value;
                OnPropertyChanged(nameof(Ciudad1));
            }
        }

        public string Ciudad2
        {
            get { return ciudad2; }
            set
            {
                ciudad2 = value;
                OnPropertyChanged(nameof(Ciudad2));
            }
        }

        public string Ciudad3
        {
            get { return ciudad3; }
            set
            {
                ciudad3 = value;
                OnPropertyChanged(nameof(Ciudad3));
            }
        }

        public string Ciudad4
        {
            get { return ciudad4; }
            set
            {
                ciudad4 = value;
                OnPropertyChanged(nameof(Ciudad4));
            }
        }

        public string LabelString => $"{Pais}";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InicializarCiudades(string ciudad1, string ciudad2, string ciudad3, string ciudad4)
        {
            Ciudad1 = ciudad1;
            Ciudad2 = ciudad2;
            Ciudad3 = ciudad3;
            Ciudad4 = ciudad4;
        }
    }
}
