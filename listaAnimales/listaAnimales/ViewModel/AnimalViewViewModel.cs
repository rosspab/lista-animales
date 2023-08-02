using System;
using System.Threading.Tasks;
using listaAnimales.Model;
using Xamarin.Forms;

namespace listaAnimales.ViewModel
{
	public class AnimalViewViewModel
	{
        public Command salvarAnimalCommand { get; set; }
        public Animal nuevoAnimal { get; set; }

        private INavigation Navigation;

        public AnimalViewViewModel(INavigation navigation)
        {
            nuevoAnimal = new Animal();
            salvarAnimalCommand = new Command(async () => await SalvarAnimal());
            Navigation = navigation;
        }

        public AnimalViewViewModel(INavigation navigation, Animal animal)
        {
            nuevoAnimal = animal;
            salvarAnimalCommand = new Command(async () => await SalvarAnimal());
            Navigation = navigation;
        }

        public async Task SalvarAnimal()
        {
            await App.DataBase.SaveItemAsync(nuevoAnimal);
            await Navigation.PopToRootAsync();
        }
    }
}

