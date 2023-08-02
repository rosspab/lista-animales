using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using listaAnimales.Helpers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using listaAnimales.Model;
using listaAnimales.View;

namespace listaAnimales.ViewModel
{
	public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Grouping<string, Animal>> Animales { get; set; }
        public Command AgregarAnimalCommand { get; set; }
        public Command ItemTappedCommand { get; set; }
        public Animal Animal
        {
            get => animal;
            set
            {
                animal = value;
                OnPropertyChanged();
            }
        }

        public INavigation Navigation;
        private Animal animal;

        public MainPageViewModel(INavigation navigation)
        {
            AnimalRepository repository = new AnimalRepository();

            Animales = repository.GetAllGrouped();

            Navigation = navigation;

            AgregarAnimalCommand = new Command(async () => await NavigateToAnimalView());

            ItemTappedCommand = new Command(async () => await NavigateToEditAnimal());

        }

        public async Task NavigateToEditAnimal()
        {
            await Navigation.PushAsync(new AnimalView(animal));
        }

        public async Task NavigateToAnimalView()
        {
            await Navigation.PushAsync(new AnimalView());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

