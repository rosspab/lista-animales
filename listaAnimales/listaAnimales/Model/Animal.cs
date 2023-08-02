using System;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace listaAnimales.Model
{
    public class Animal : INotifyPropertyChanged
    {
        private string nombre;
        private string especie;
        private string ubicacion;
        private string imagen;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }
        public string Especie
        {
            get => especie;
            set
            {
                especie = value;
                OnPropertyChanged();
            }
        }
        public string Ubicacion
        {
            get => ubicacion;
            set
            {
                ubicacion = value;
                OnPropertyChanged();
            }
        }
        public string Imagen
        {
            get => imagen;
            set
            {
                imagen = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

