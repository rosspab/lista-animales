using listaAnimales.ViewModel;
using listaAnimales.Model;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace listaAnimales.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimalView : ContentPage
	{	
		public AnimalView (Animal animal = null)
		{
			InitializeComponent ();
            if (animal == null)
            {
                BindingContext = new AnimalViewViewModel(Navigation);
            }
            else
            {
                BindingContext = new AnimalViewViewModel(Navigation, animal);
            }
        }
	}
}

